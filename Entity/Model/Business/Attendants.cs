using Entity.Enum;
using Entity.Model.Global;
using Entity.Model.Security;

namespace Entity.Model.Business
{
    public class Attendants : ABaseEntity
    {
        public int PersonId { get; set; }

        public int? StudentId { get; set; }

        public RelationShipTypeEnum? RelationShipTypeEnum { get; set; }
        public Person Person { get; set; }

        public Student Student { get; set; }
    }
}
