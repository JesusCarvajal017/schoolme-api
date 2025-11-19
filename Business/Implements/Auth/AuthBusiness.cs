using Business.Implements.Querys.Especific;
using Data.Implements.Auth;
using Entity.Dtos.Especific.System;
using Entity.Dtos.Security.Auth;
using Microsoft.Extensions.Logging;
using Utilities.Exceptions;


namespace Business.Implements.Auth
{
    public class AuthBusiness : IAuth
    {
        protected readonly LoginData _data;
        protected readonly ILogger<AuthBusiness> _logger;

        public AuthBusiness(LoginData d, ILogger<AuthBusiness> logger)
        {
            _data = d;
            _logger = logger;
        }

        public async Task<Object> AuthApp(CredencialesDto login)
        {
            try
            {
                if (login == null)
                    throw new ExternalServiceException("Base de datos", $"acceso denegado:  {login.Email}");

                var updated = await _data.ValidarLoginAsync(login);

                if (updated == null)
                {
                    return new { message = "Acceso denegado, crendenciales incorrectas" };
                }


                return updated;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al dar acceso {login.Email}");
                throw new ExternalServiceException("Base de datos", $"Error acceso no autorizado {login.Email}", ex);
            }
        }

        /// <summary>
        /// Metodo encargado de la recuperacion de contraseña, valida que el correo electronico este en el sistema
        /// y luego envia un codigo de verificación a correo para su posterios actualizacion de contraseña
        /// <summary>
        public async Task<StatusDto> ResetPasswordServices(string email)
        {
            try
            {
                // validar si el email esta en la base de datos
                var updated = await _data.ValidationEmail(email);

                if (!updated)
                {
                    return new StatusDto { Description = "Este correo electronico no esta vinculado en el sistema", Status = false };
                }


                return new StatusDto { Description = $"El codigo fue enviado a su correo electronico", Status = true }; ;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error en el proceso de valiacion y envio de codigo de seguridad");
                throw new ExternalServiceException("Procesos de gestion", $"Error de valicacion y generacion de codigo de seguridad", ex);
            }
        }

        public async Task<StatusDto> ValidateCodigo(string email, string codigo)
        {
            try
            {
                // validar si el email esta en la base de datos
                var updated = await _data.VerifyResetCodeAsync(email,codigo);

                if (!updated.Status)
                {
                    return new StatusDto { Description = "Codigo incorrecto, intente nuevamente", Status = false };
                }

                updated.Description = "Codigo correcto, recuperacion de contraseña exitoso";

                return updated;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error en la validacion de codigo");
                throw new ExternalServiceException("Procesos de gestion", $"Error de valicacion y generacion de codigo de seguridad", ex);
            }
        }



    }
}
