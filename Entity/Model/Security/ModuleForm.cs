using Entity.Model.Global;

namespace Entity.Model.Security
{
    public class ModuleForm : ABaseEntity
    {
        public int ModuleId { get; set; }
        public int FormId { get; set; }

        public Module Module { get; set; } 
        public Form Form { get; set; } 

    }
}
