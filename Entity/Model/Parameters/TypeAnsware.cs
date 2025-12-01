using Entity.Model.Business;
using Entity.Model.Global;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Model.Paramters
{
    public class TypeAnsware : ABaseEntity
    {
        public string Name { get; set; } = null!;   // Ej: Text, Bool, Number, Date, OptionSingle, OptionMulti
        public string? Description { get; set; }       


        [NotMapped]
        public virtual ICollection<Question> Questions { get; set; }
    }
}
