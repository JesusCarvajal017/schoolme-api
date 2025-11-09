using Entity.Dtos.Global;

namespace Entity.Dtos.Business.StudentAnsware
{
    public class StudentAnswareDto : ABaseDto
    {
        public int? AgendaDayStudentId { get; set; }
        public int? QuestionId { get; set; }

        // Valores posibles según el tipo de respuesta
        public string? ValueText { get; set; }
        public bool? ValueBool { get; set; }
        public decimal? ValueNumber { get; set; }   // si necesitas precisión fija, configura el tipo en Fluent API
        public DateTime? ValueDate { get; set; }


    }
}
