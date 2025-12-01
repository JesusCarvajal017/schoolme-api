using Entity.Dtos.Global;

namespace Entity.Dtos.Business.AgendaDayStudent
{
    public class AgendaDayStudentDto : ABaseDto
    {
        public int? AgendaDayId { get; set; }
        public int? StudentId { get; set; }
        public int? AgendaDayStudentStatus { get; set; }
        public DateTime? CompletedAt { get; set; } // cuando completo la agenda de ese estudiante
    }
}
