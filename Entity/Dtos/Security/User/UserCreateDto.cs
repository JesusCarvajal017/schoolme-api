using Microsoft.AspNetCore.Http;

namespace Entity.Dtos.Security.User
{
    public class UserCreateDto 
    {
        // todo estan en string porque desde el front se envia un formData, y este
        // solo puede mandar tipo string

        public IFormFile? Photo { get; set; }
        public string? Email { get; set; }
        public string? PersonId { get; set; }
        public string? Id { get; set; }
        public string? Status { get; set; }
    }
}
