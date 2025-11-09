using Entity.Model.Business;
using Entity.Model.Global;

namespace Entity.Model.Paramters
{
    public class Eps : ABaseEntity
    {
        public string Name { get; set; }
        public IEnumerable<DataBasic> DataBasics { get; set; }
    }
}
