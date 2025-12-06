using Entity.Model.Global;
using Entity.Model.Paramters;

namespace Entity.Model.Business
{
    public class AcademicLoad : ABaseEntity
    {
        public int TeacherId { get; set; }
        public int SubjectId { get; set; }
        public int GroupId { get; set; }
        public int? Days { get; set; }   
        public  Teacher Teacher { get; set; }
        public  Subject Subject { get; set; }
        public  Groups Group { get; set; }

        public IEnumerable<TeacherObservation> TeacherObservations { get; set; }
    }
}
