using Entity.Model.Business;
using Entity.Model.Global;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Model.Paramters
{
    public class Subject : ABaseEntity
    {
        public string Name { get; set; }

        //[NotMapped]
        public ICollection<AcademicLoad> AcademicLoads { get; set; }
    }
}
