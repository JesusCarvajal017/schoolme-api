using Entity.Dtos.Global;

namespace Entity.Dtos.Security.ModuleForm
{
    public class ModuleFormCreation : ABaseDto
    {
        public int? ModuleId { get; set; }
        public int? FormId { get; set; }

    }
}
