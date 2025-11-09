using Entity.Dtos.Global;

namespace Entity.Dtos.Security.UserRol
{
    public class UserRolDto : ABaseDto
    {
        public int? UserId { get; set; }
        public string? NameUser { get; set; }

        public int? RolId { get; set; }
        public string? RolName { get; set; }

    }
}
