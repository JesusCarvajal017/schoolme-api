using Entity.Model.Business;
using Entity.Model.Global;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Model.Paramters
{
    public class TypeAnsware : ABaseEntity
    {
        public string Name { get; set; } = null!;   // Ej: Text, Bool, Number, Date, OptionSingle, OptionMulti
        public string? Description { get; set; }        // 1=activo, 0=inactivo (ajusta a tu enum si lo tienes)

        // Navegación: un tipo tiene muchas preguntas

        [NotMapped]
        public virtual ICollection<Question> Questions { get; set; }
    }
}
