using Microsoft.AspNetCore.SignalR;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Web.Extendes
{
    public static class AddJwtServices
    {
        public static IServiceCollection AddJwtConfig(this IServiceCollection services, IConfiguration configuracion)
        {
            services.AddAuthentication().AddJwtBearer(opciones =>
            {
                opciones.MapInboundClaims = false;

                opciones.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuracion["JWT:Key"])),
                    ClockSkew = TimeSpan.Zero
                };
            }
            );
            return services;

        }
    }


    public class JwtUserIdProvider : IUserIdProvider
    {
        public string? GetUserId(HubConnectionContext connection)
        {
            // lee el claim "userId" del JWT
            return connection.User?.FindFirst("userId")?.Value;
        }
    }
}
