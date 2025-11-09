using Entity.Dtos.Global;

namespace Entity.Dtos.Security.RolFormPermission
{
    public class RolFormPermissionCreateDto : ABaseDto
    {
        public int? RolId { get; set; }
        public int? FormId { get; set; }
        public int? PermissionId { get; set; }
    }
}
