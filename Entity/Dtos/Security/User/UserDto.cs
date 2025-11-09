using Entity.Dtos.Global;
using Microsoft.AspNetCore.Http;

namespace Entity.Dtos.Security.User
{
    public class UserDto : ABaseDto
    {
        // todo estan en string porque desde el front se envia un formData, y este
        // solo puede mandar tipo string
        public IFormFile? Photo { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; } // Por seguridad
        public bool? TwoStep { get; set; } = false;
        public int? PersonId { get; set; }
    }
}
