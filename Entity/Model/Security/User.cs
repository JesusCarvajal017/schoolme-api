using Entity.Model.Global;

namespace Entity.Model.Security
{
    public class User : ABaseEntity
    {
        public string? Photo { get; set; }
        public string Email { get; set; } 
        public string Password { get; set; } 
        public int PersonId { get; set; }
        public bool TwoStep { get; set; } = false;
        public Person Person { get; set; }
        public ICollection<UserRol> UserRol { get; set; }
    }
}
