using Entity.Model.Business;
using Entity.Model.Global;

namespace Entity.Model.Paramters
{
    public class Rh : ABaseEntity
    {
        public string Name { get; set; }

        public IEnumerable<DataBasic> DataBasics { get; set; }
    }
}
