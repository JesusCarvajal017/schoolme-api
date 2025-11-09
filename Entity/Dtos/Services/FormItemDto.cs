using System.Text;

namespace Entity.Dtos.Services
{
    public class FormItemDto
    {
        public string? Name { get; set; } = default!;
        public string? Permission { get; set; } = default!;

        public string? Path { get; set; } = default!;
        public int? Orden { get; set; }
    }
}
