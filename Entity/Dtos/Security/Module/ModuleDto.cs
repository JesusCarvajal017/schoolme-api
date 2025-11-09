using Entity.Dtos.Global;

namespace Entity.Dtos.Security.Module
{
    public class ModuleDto : ABaseDto
    {
        public string? Name { get; set; }
        public string? Icon { get; set; }

        public string? Path { get; set; }
        public int? Orden { get; set; }
        public string? Description { get; set; }
    }
}
