using Entity.Dtos.Global;

namespace Entity.Dtos.Security.User
{
    public class UserQueryDto : ABaseDto
    {
        public string? Photo { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; } // Por seguridad
        public int? PersonId { get; set; }
    }
}
