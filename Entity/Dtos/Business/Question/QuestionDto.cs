using Entity.Dtos.Global;

namespace Entity.Dtos.Business.Question
{
    public class QuestionDto : ABaseDto
    {
        public string? Text { get; set; } = null!;
        public int? TypeAnswerId { get; set; }

    }
}
