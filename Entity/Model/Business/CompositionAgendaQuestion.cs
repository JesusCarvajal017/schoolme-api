using Entity.Model.Global;

namespace Entity.Model.Business
{
    public class CompositionAgendaQuestion : ABaseEntity
    {
        // FKs
        public int AgendaId { get; set; }
        public int QuestionId { get; set; }

        // Navegación
        public Agenda Agenda { get; set; } = null!;
        public Question Question { get; set; } = null!;

    }
}
