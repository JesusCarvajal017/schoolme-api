using Entity.Model.Business;
using Entity.Model.Global;

namespace Entity.Model.Paramters
{
    public class Groups : ABaseEntity
    {
        public string Name { get; set; }
        public int GradeId { get; set; }
        public int AmountStudents { get; set; }
        public int? AgendaId { get; set; }

        public Agenda? Agenda { get; set; }
        public Grade Grade { get; set; }
        public GroupDirector GroupDirector { get; set; }

        public ICollection<AcademicLoad> AcademicLoad { get; set; }
        public ICollection<AgendaDay> AgendaDay { get; set; }
    }
}
