using Entity.Dtos.Global;

namespace Entity.Dtos.Security.ModuleForm
{
    public class ModuleFormDto : ABaseDto
    {
        public int? ModuleId { get; set; }
        public string? ModuleName { get; set; }
        public int? FormId { get; set; }
        public string? FormName { get; set; }
    }
}
