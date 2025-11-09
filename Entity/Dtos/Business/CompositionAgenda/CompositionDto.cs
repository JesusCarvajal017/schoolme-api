using Entity.Dtos.Global;

namespace Entity.Dtos.Business.CompositionAgenda
{
    public class CompositionDto : ABaseDto
    {
        public int? AgendaId { get; set; }
        public int? QuestionId { get; set; }
    }
}
