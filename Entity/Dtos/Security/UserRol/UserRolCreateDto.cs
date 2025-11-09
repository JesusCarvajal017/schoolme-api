using Entity.Dtos.Global;

namespace Entity.Dtos.Security.UserRol
{
    public class UserRolCreateDtos : ABaseDto
    {
        public int? UserId { get; set; }
        public int? RolId { get; set; }
    }
}
