namespace Entity.Dtos.Services
{
    public class MenuDto
    {
        public string Name { get; set; } = default!;
        public string Icon { get; set; } = default!;
        public string Path { get; set; } = default!;
        public int Order { get; set; }
        public List<FormItemDto> Formularios { get; set; } = new();
    }
}
