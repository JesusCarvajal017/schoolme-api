using Entity.Model.Global;
using Entity.Model.Paramters;

namespace Entity.Model.Business
{
    public class Tutition : ABaseEntity
    {
        public int StudentId { get; set; }
        public int GradeId { get; set; }

        public Student Student { get; set; }
        public Grade Grade { get; set; }
    }
}
