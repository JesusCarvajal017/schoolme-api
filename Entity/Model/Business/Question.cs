using Entity.Model.Global;
using Entity.Model.Paramters;

namespace Entity.Model.Business
{
    public class Question : ABaseEntity
    {
        public string Text { get; set; } = null!;
        public int TypeAnswerId { get; set; }

        // Navegación
        public TypeAnsware TypeAswer { get; set; } = null!;

        public ICollection<QuestionOption> QuestionOptions { get; set; } 
        public ICollection<CompositionAgendaQuestion> CompositionAgendaQuestion { get; set; }
        public ICollection<StudentAnswer> StudentAnswers { get; set; } 

    }
}
