using Entity.Model.Global;

namespace Entity.Model.Security
{
    public class Module : ABaseEntity
    {
        public string Name { get; set; } 
        public string Icon { get; set; }
        public string Path { get; set; }

        public int Order { get; set; } = default!;

        public string Description { get; set; } 

        public ICollection<ModuleForm> ModuleForm { get; set; }
    }
}
