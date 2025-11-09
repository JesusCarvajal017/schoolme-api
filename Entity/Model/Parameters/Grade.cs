
using Entity.Model.Business;
using Entity.Model.Global;

namespace Entity.Model.Paramters
{
    public class Grade : ABaseEntity
    {
        public string Name { get; set; }
        public IEnumerable<Tutition> Tutition { get; set; }
    }
}
