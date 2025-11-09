using Entity.Model.Global;
using Entity.Model.Paramters;

namespace Entity.Model.Business
{
    public class AgendaDay : ABaseEntity
    {
        public int GroupId { get; set; }
        public int AgendaId { get; set; }
        public DateOnly Date { get; set; }
        public DateTime? OpenedAt { get; set; }
        public DateTime? ClosedAt { get; set; }

        public Groups Group { get; set; }
        public Agenda Agenda { get; set; } 
        public ICollection<AgendaDayStudent> AgendaDayStudents { get; set; }

    }
}
