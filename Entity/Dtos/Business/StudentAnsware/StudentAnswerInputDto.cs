using Entity.Dtos.Global;

namespace Entity.Dtos.Business.StudentAnsware
{
    public class StudentAnswerInputDto : ABaseDto
    {
        public int QuestionId { get; set; }

        public string? ValueText { get; set; }
        public bool? ValueBool { get; set; }
        public decimal? ValueNumber { get; set; }
        public DateTime? ValueDate { get; set; }

        // ids de opciones seleccionadas (para OptionSingle / OptionMulti)
        public List<int>? OptionIds
        {
            get; set;
        }
    }
}
