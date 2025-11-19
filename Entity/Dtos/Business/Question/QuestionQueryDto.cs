using Entity.Dtos.Global;

namespace Entity.Dtos.Business.Question
{
    public class QuestionQueryDto : ABaseDto
    {
        public string? Text { get; set; } = null!;
        public int? TypeAnswerId { get; set; }
        public string? NameAnswer {  get; set; }

    }
}
