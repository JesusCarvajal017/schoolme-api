using Entity.Dtos.Global;

namespace Entity.Dtos.Business.StudentAnsware
{
    public class RegisterGlobalStudentAnswersDto : ABaseDto
    {
        public int AgendaDayId { get; set; }              // agenda_day_id del día
        public int GroupId { get; set; }                  // grupo al que se aplica
        public List<StudentAnswerInputDto> Answers { get; set; } = new();


    }
}
