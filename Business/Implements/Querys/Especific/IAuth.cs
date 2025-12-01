using Entity.Dtos.Especific.System;
using Entity.Dtos.Security.Auth;

namespace Business.Implements.Querys.Especific
{
    
    public interface IAuth
    {
        Task<Object> AuthApp(CredencialesDto login);
        Task<StatusDto> ResetPasswordServices(string email);
        Task<StatusDto> ValidateCodigo(string email, string codigo);
    }
   
}
