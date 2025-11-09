using Entity.Dtos.Global;

namespace Entity.Dtos.Business.QuestionOption
{
    public class QuestionOptionDto : ABaseDto
    {
        public int? QuestionId { get; set; }
        public string? Text { get; set; } = null!;
        public int? Order { get; set; }

    }
}
