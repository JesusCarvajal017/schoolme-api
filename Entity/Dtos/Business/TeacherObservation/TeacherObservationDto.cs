using Entity.Dtos.Global;

namespace Entity.Dtos.Business.TeacherObservation
{
    public class TeacherObservationDto : ABaseDto
    {
        public int? TeacherId { get; set; }
        public int? AgendaDayStudentId { get; set; }
        public string? Text { get; set; }
        public int? AcademicLoadId { get; set; }
      



    }
}
