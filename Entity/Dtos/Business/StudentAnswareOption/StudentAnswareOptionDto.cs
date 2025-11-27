using Entity.Dtos.Global;

namespace Entity.Dtos.Business.StudentAnswareOption
{
    public class StudentAnswareOptionDto : ABaseDto
    {
        public int? StudentAnswerId { get; set; }
        public int? QuestionOptionId { get; set; }

    }
}
