using Entity.Dtos.Global;

namespace Entity.Dtos.Business.Tution
{
    public class TutionDto : ABaseDto
    {
        public int StudentId { get; set; }

        public int GradeId { get; set; }
    }
}
