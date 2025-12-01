using Entity.Model.Global;

namespace Entity.Model.Business
{
    public class AgendaDayStudent : ABaseEntity
    {
        public int AgendaDayId { get; set; }
        public int StudentId { get; set; }
        public int AgendaDayStudentStatus { get; set; }
        public DateTime? CompletedAt {  get; set; } // cuando completo la agenda de ese estudiante

        // Navegación
        public AgendaDay AgendaDay { get; set; } = null!;
        public Student Student { get; set; } = null!;
        public ICollection<StudentAnswer> StudentAnswers { get; set; } = new List<StudentAnswer>();
        public ICollection<TeacherObservation> TeacherObservation { get; set; }

    }
}
