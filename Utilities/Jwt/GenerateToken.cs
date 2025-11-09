using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Entity.Dtos.Security.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Utilities.Jwt
{
    public class GenerateToken
    {
        private IConfiguration _configuration;
        public GenerateToken(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // <summary>
        // Metodo que genera el token JWT y que por el momento solo almacenara el Id de usuario
        // </summary>
        public async Task<AuthDto> GeneradorToken(int id, int rol )
        {
            var claims = new List<Claim>
            {
                new Claim("rol", id.ToString()),
                new Claim("id", rol.ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiracion = DateTime.UtcNow.AddHours(1);

            var tokenSeguridad = new JwtSecurityToken(issuer: null, audience: null, claims: claims, expires: expiracion, signingCredentials: creds);

            var token = new JwtSecurityTokenHandler().WriteToken(tokenSeguridad);

            return new AuthDto
            {
                Token = token,
                Expiracion = expiracion
            };
        }
    }
}

