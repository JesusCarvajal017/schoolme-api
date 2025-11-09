using Entity.Model.Global;
using Entity.Model.Paramters;

namespace Entity.Model.Business
{
    public class QuestionOption : ABaseEntity
    {
        // FK
        public int QuestionId { get; set; }
        public string Text { get; set; } = null!;
        public int Order { get; set; }

        // Navegación
        public virtual Question Question { get; set; } = null!;
        public virtual ICollection<StudentAnswerOption> StudentAnswerOptions { get; set; } = new HashSet<StudentAnswerOption>();

    }
}
