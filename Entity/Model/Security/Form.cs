using Entity.Model.Global;

namespace Entity.Model.Security
{
    public class Form : ABaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        public int Order {  get; set; }

        public ICollection<RolFormPermission> RolFormPermission { get; set; } 
        public ICollection<ModuleForm> ModuleForm { get; set; } 

    }
}
