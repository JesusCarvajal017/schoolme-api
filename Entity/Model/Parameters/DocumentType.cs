using Entity.Model.Global;
using Entity.Model.Security;

namespace Entity.Model.Paramters
{
    public class DocumentType : ABaseEntity
    {
        public string Name { get; set; }
        public string Acronym { get; set; }
        

        public IEnumerable<Person> Persons {  get; set; }
    }
}
