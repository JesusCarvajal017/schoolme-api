using Microsoft.AspNetCore.Http;

namespace Entity.Dtos.Especific
{
    public class ChangePhotoDto
    {
        public int Id { get; set; }
        public IFormFile Photo { get; set; }
    }
}
