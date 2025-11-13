using Entity.Enum;
using Entity.Model.Business;
using Entity.Model.Global;
using Entity.Model.Paramters;

namespace Entity.Model.Security
{
    public class Person : ABaseEntity
    {
        public int DocumentTypeId { get; set; }
        public long Identification { get; set; }
        public string FisrtName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string SecondLastName { get; set; }
        //public string Nation { get; set; }
        public long Phone { get; set; }
        public GenderEmun Gender { get; set; }
        public int Age { get; set; }
        public DocumentType DocumentType { get; set; }
        public DataBasic DataBasic { get; set; }
        public ICollection<Attendants> Attendants { get; set; }
        public User? User { get; set; }

    }
}
