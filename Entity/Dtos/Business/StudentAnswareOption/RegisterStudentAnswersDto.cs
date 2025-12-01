using Entity.Dtos.Business.StudentAnsware;
using Entity.Dtos.Global;

namespace Entity.Dtos.Business.StudentAnswareOption
{
    public class RegisterStudentAnswersDto : ABaseDto
    {
        public int AgendaDayStudentId { get; set; }
        public List<StudentAnswerInputDto> Answers { get; set; } = new();
    }
}
