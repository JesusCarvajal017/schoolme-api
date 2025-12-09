using Entity.Dtos.Global;

namespace Entity.Dtos.Business.TeacherObservation
{
    public class TeacherObservationQueryDto: ABaseDto
    {
        public int TeacherId { get; set; }
        public int AgendaDayStudentId { get; set; }

        public int? AcademicLoadId { get; set; }

        public string Text { get; set; }

        public string TeacherName { get; set; }      
        public string SubjectName { get; set; }      
        public string GroupName { get; set; }        
        public string GradeName { get; set; }


    }
}
