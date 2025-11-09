using Entity.Model.Global;

namespace Entity.Model.Security
{
    public class UserRol : ABaseEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RolId { get; set; }

        public User User { get; set; }
        public Rol Rol { get; set; }
    }
}
