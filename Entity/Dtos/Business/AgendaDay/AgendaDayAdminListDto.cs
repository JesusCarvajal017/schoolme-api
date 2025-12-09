using Entity.Dtos.Global;
using Entity.Enum;

namespace Entity.Dtos.Business.AgendaDay
{
    public class AgendaDayAdminListDto : ABaseDto
    {
        public int AgendaDayId { get; set; }
        public int AgendaId { get; set; }
        public int GroupId { get; set; }

        public string AgendaName { get; set; }
        public string GroupName { get; set; }

        public DateOnly Date { get; set; }

        public AgendaDayStateEnum State { get; set; }
    }

}
