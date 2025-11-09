using Entity.Model.Global;
using Entity.Model.Security;

namespace Entity.Model.Business
{
    public class Teacher : ABaseEntity
    {
        public int PersonId { get; set; } 
        public Person Person { get; set; }



        public ICollection<GroupDirector> GroupDirector { get; set; }
        public ICollection<AcademicLoad> AcademicLoad { get; set; }
        public ICollection<TeacherObservation> TeacherObservation { get; set; }

    }
}
