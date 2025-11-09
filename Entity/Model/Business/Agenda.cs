using Entity.Model.Global;
using Entity.Model.Paramters;

namespace Entity.Model.Business
{
    public class Agenda : ABaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<AgendaDay> AgendaDays { get; set; }
        public ICollection<Groups> Groups { get; set; }

        public ICollection<CompositionAgendaQuestion> CompositionAgendaQuestion { get; set; }


        // Si "compositionAgenda" es una relación hacia otra entidad, 
        // habría que aclarar a qué apunta (puede ser una relación de composición)

        //public ICollection<Agenda> CompositionAgenda { get; set; 
    }
}
