using Entity.Model.Business;
using Entity.Model.Global;

namespace Entity.Model.Paramters
{
    public class Munisipality : ABaseEntity
    {
        public string Name { get; set; }
        public int DepartamentId { get; set; }
        public Departament Departament { get; set; }
        public IEnumerable<DataBasic> DataBasics { get; set; }
    }
}
