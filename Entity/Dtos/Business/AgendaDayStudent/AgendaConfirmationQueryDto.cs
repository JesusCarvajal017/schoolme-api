using Entity.Dtos.Global;

namespace Entity.Dtos.Business.AgendaDayStudent
{
    public class AgendaConfirmationQueryDto : ABaseDto
    {
        public int AgendaId { get; set; }
        public int AgendaDayId { get; set; }
        public int AgendaDayStudentId { get; set; }

        public string AgendaName { get; set; }
        public string GroupName { get; set; }

        public DateOnly Date
        {
            get; set;
        }
    }
}
