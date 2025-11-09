using Entity.Dtos.Global;

namespace Entity.Dtos.Security.Form
{
    public class FormDto : ABaseDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Path { get; set; }
        public int? Order { get; set; }
    }
}
