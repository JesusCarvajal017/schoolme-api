using Data.Interfaces.Group.Querys;
using Entity.Context.Main;
using Entity.Dtos.Especific.System;
using Entity.Dtos.Security.Auth;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Utilities.Helpers.interfaces;
using Utilities.Jwt;
using Utilities.Redis.Interface;

namespace Data.Implements.Auth
{
    public class LoginData
    {
        private AplicationDbContext _contenxt;
        private ILogger<LoginData> _logger;
        private readonly GenerateToken _jwt;
        private readonly IQuerysUserRol _queryUserRol;
        private readonly IPasswordResetStore _resetStore;
        private readonly IEmailSender _emailSender;

        public LoginData(AplicationDbContext context, ILogger<LoginData> logger, GenerateToken jwt,
            IQuerysUserRol queryUserRol, IPasswordResetStore resetStore,
            IEmailSender servicesEmail
            )
        {
            _contenxt = context;
            _logger = logger;
            _jwt = jwt;
            _queryUserRol = queryUserRol;
            _resetStore = resetStore;
            _emailSender = servicesEmail;
        }

        //<summary>
        // metodo que valida si el usuario existe en el sistema y asi poder validar sus credenciales
        //<summary>
        public async Task<AuthDto> ValidarLoginAsync(CredencialesDto credenciales)
        {
            //busqueda del usuario por nombre
            var user = await _contenxt.Set<User>()
                .FirstOrDefaultAsync(u => u.Email == credenciales.Email);

            if (user != null && BCrypt.Net.BCrypt.Verify(credenciales.Password, user.Password))
            {

                var queryRol = await _queryUserRol.QueryUserRol(user.Id);
                var uniqueRol = queryRol.FirstOrDefault();


                var token = await _jwt.GeneradorToken(user.PersonId, uniqueRol.RolId, user.Id);

                return token;
            }
            return null;
        }


        /// <summary>
        /// Valida el correo electronico y envia un email con el codigo con una expiración de 10 min
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<bool> ValidationEmail(string email)
        {
            // 1) verificar existencia (sin revelar detalles fuera)
            var user = await _contenxt.Set<User>()
                                      .AsNoTracking()
                                      .FirstOrDefaultAsync(u => u.Email == email);

            if (user == null) { 
                Console.WriteLine("codigo no encontrado");
                return false;
            }

            // tiempo de vida del código.Despues de eso la implemetancion expira y elimina la clave automáticamente
            var ttl = TimeSpan.FromMinutes(10);

            // evita que el mismo usuario solicite el codigo en ráfaga : segundos anti-spam
            var cooldown = 60; 

            // code = valor plano del codigo a enviar por email, expireAt = es la fecha / hora de expiracion, informacion para el usuario
            var (code, expiresAt) = await _resetStore.CreateOrReplaceAsync(user.Id.ToString(), ttl, cooldown);

            CodeF2Dto infoCodigo = new CodeF2Dto { Code = int.Parse(code) };

            // pasando parametros para enviar el correo electronico
            await _emailSender.SendTemplateAsync(
                toEmail: email,
                subject: "Bienvenido a SchoolMe",
                templateKey: "Helpers.messageEmail.template.VerficationCode.cshtml",
                model: infoCodigo
            );


            return true; // éxito
        }

        // Si luego quieres validar/consumir el código desde Data:
        public async Task<StatusDto> VerifyResetCodeAsync(string email, string code)
        {
            var userId = await _contenxt.Set<User>()
                                        .Where(u => u.Email == email)
                                        .Select(u => u.Id.ToString())
                                        .FirstOrDefaultAsync();

            if (userId is null) return new StatusDto { Status = false};

            var ok = await _resetStore.VerifyAndConsumeAsync(userId, code, maxAttempts: 5);

            int idUser = int.Parse(userId);

            return new StatusDto
            {
                Status = ok,
                Data = new GenericIdsDto { Id= idUser } 
            };
        }



    }
}
