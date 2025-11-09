using Entity.Model.Global;

namespace Entity.Model.Business
{
    public class StudentAnswer : ABaseEntity
    {
        public int AgendaDayStudentId { get; set; }
        public int QuestionId { get; set; }

        // Valores posibles según el tipo de respuesta
        public string? ValueText { get; set; }
        public bool? ValueBool { get; set; }
        public decimal? ValueNumber { get; set; }   // si necesitas precisión fija, configura el tipo en Fluent API
        public DateTime? ValueDate { get; set; }

        // Navegación
        public AgendaDayStudent AgendaDayStudent { get; set; } = null!;
        public Question Question { get; set; } = null!;

        // Muchas opciones seleccionadas (para preguntas de selección múltiple)
        public virtual ICollection<StudentAnswerOption> SelectedOptions { get; set; } = new HashSet<StudentAnswerOption>();

    }
}
