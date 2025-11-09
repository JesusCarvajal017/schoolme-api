using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Utilities.Redis.Interface;

namespace Utilities.Redis.Implement
{
    public class PasswordResetStoreRedis : IPasswordResetStore
    {
        private readonly IConnectionMultiplexer _redis;
        private readonly byte[] _hmacSecret;

        public PasswordResetStoreRedis(IConnectionMultiplexer redis, IConfiguration cfg)
        {
            _redis = redis;
            var b64 = cfg["PasswordReset:HmacSecretBase64"] ?? throw new InvalidOperationException("Missing HMAC secret");
            _hmacSecret = Convert.FromBase64String(b64);
        }

        private static string Key(string userId) => $"pwdreset:{userId}";
        private static string CooldownKey(string userId) => $"pwdresetcd:{userId}";

        private static string GenerateCode5()
        {
            var b = new byte[4];
            RandomNumberGenerator.Fill(b);
            var num = Math.Abs(BitConverter.ToInt32(b, 0)) % 100000;
            return num.ToString("D5");
        }

        private (string hash, string salt) HashCode(string code)
        {
            var saltBytes = RandomNumberGenerator.GetBytes(16);
            var salt = Convert.ToBase64String(saltBytes);
            using var hmac = new HMACSHA256(_hmacSecret);
            var mac = hmac.ComputeHash(Encoding.UTF8.GetBytes(code + salt));
            return (Convert.ToBase64String(mac), salt);
        }

        private bool VerifyHash(string code, string salt, string expectedHash)
        {
            using var hmac = new HMACSHA256(_hmacSecret);
            var mac = hmac.ComputeHash(Encoding.UTF8.GetBytes(code + salt));
            return CryptographicOperations.FixedTimeEquals(Convert.FromBase64String(expectedHash), mac);
        }

        private record Entry(string CodeHash, string Salt, DateTime CreatedAtUtc, DateTime ExpiresAtUtc, bool Used, int Attempts);


        /// <summary>
        ///  Genera un código numérico de 5 dígitos.
        ///  Hashea el código con HMAC.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="ttl"></param>
        /// <param name="resendCooldownSeconds"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task<(string Code, DateTime ExpiresAt)> CreateOrReplaceAsync(string userId, TimeSpan ttl, int resendCooldownSeconds = 60)
        {
            var db = _redis.GetDatabase();

            if (await db.KeyExistsAsync(CooldownKey(userId)))
                throw new InvalidOperationException("Espera antes de volver a solicitar el código.");

            var code = GenerateCode5();
            var (hash, salt) = HashCode(code);
            var now = DateTime.UtcNow;
            var expires = now.Add(ttl);
            var entry = new Entry(hash, salt, now, expires, Used: false, Attempts: 0);

            await db.StringSetAsync(Key(userId), JsonSerializer.Serialize(entry), ttl);
            await db.StringSetAsync(CooldownKey(userId), "1", TimeSpan.FromSeconds(resendCooldownSeconds));

            return (code, expires);
        }

        public async Task<bool> VerifyAndConsumeAsync(string userId, string code, int maxAttempts = 5)
        {
            var db = _redis.GetDatabase();
            var json = await db.StringGetAsync(Key(userId));
            if (json.IsNullOrEmpty) return false;

            var entry = JsonSerializer.Deserialize<Entry>(json!)!;
            if (entry.Used || entry.ExpiresAtUtc <= DateTime.UtcNow) return false;
            if (entry.Attempts >= maxAttempts) return false;

            var ok = VerifyHash(code, entry.Salt, entry.CodeHash);
            if (ok)
            {
                await db.KeyDeleteAsync(Key(userId)); // consumo one-time
                return true;
            }

            var ttl = await db.KeyTimeToLiveAsync(Key(userId)) ?? TimeSpan.FromMinutes(1);
            var updated = entry with { Attempts = entry.Attempts + 1 };
            await db.StringSetAsync(Key(userId), JsonSerializer.Serialize(updated), ttl);
            return false;
        }

    }
}
