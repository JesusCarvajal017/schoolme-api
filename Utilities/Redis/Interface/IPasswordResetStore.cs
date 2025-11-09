namespace Utilities.Redis.Interface
{
    public interface IPasswordResetStore
    {
        Task<(string Code, DateTime ExpiresAt)> CreateOrReplaceAsync(string userId, TimeSpan ttl, int resendCooldownSeconds = 60);
        Task<bool> VerifyAndConsumeAsync(string userId, string code, int maxAttempts = 5);
    }
}
