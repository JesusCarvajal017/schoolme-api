using Entity.Model.Business;
using Entity.Model.Global;

namespace Entity.Model.Paramters
{
    public class MaterialStatus : ABaseEntity
    {
        public string Name { get; set; }
        public IEnumerable<DataBasic> DataBasic { get; set; }
    }
}
