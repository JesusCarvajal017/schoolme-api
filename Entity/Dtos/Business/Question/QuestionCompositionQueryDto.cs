using Entity.Dtos.Business.CompositionAgenda;
using Entity.Dtos.Global;

namespace Entity.Dtos.Business.Question
{
    public class QuestionCompositionQueryDto : ABaseDto
    {
        public string? Text { get; set; } = null!;
        public int? TypeAnswerId { get; set; }
        public string? NameAnswer {  get; set; }

        public List<QuestionOptionCompositionDto> Options { get; set; } = new();

    }
}
