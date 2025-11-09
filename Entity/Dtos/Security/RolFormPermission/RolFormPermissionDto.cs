using Entity.Dtos.Global;

namespace Entity.Dtos.Security.RolFormPermission
{
    public class RolFormPermissionDto : ABaseDto
    {
        
        public int? RolId { get; set; }

        public string? RolName { get; set; }

        public int? FormId { get; set; }
        public string? FormName { get; set; }
        public int? PermissionId { get; set; }

        public string? PermissionName { get; set; }
    }
}
