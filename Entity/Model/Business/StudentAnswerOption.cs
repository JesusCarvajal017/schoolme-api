using Entity.Model.Global;

namespace Entity.Model.Business
{
    public class StudentAnswerOption : ABaseEntity
    {
        public int StudentAnswerId { get; set; }
        public int QuestionOptionId { get; set; }

        public StudentAnswer StudentAnswer { get; set; } = null!;
        public QuestionOption QuestionOption { get; set; } = null!;

    }
}
