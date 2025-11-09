using Entity.Dtos.Global;

namespace Entity.Dtos.Business.AgendaDay
{
    public class AgendaDayDto : ABaseDto
    {
        public int? GroupId { get; set; }
        public int? AgendaId { get; set; }
        public DateOnly? Date { get; set; }
        public DateTime? OpenedAt { get; set; }
        public DateTime? ClosedAt { get; set; }
    }
}
