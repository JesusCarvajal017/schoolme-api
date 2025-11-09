using Entity.Model.Global;

namespace Entity.Model.Security
{
    public class Permission : ABaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; } 

        public ICollection<RolFormPermission> RolFormPermission { get; set; } 
    }
}
