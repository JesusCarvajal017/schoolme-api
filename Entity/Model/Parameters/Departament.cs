using Entity.Model.Business;
using Entity.Model.Global;

namespace Entity.Model.Paramters
{
    public class Departament : ABaseEntity
    {
        public string Name { get; set; }
        public IEnumerable<Munisipality> Munisipalitys { get; set; }
    }
}
