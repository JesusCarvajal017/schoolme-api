using Entity.Model.Global;

namespace Entity.Model.Security
{
    public class RolFormPermission : ABaseEntity
    {
        public int RolId { get; set; }
        public int FormId { get; set; }
        public int PermissionId { get; set; }

        public Rol Rol { get; set; }
        public Form Form { get; set; }
        public Permission Permission { get; set; }
    }
}
