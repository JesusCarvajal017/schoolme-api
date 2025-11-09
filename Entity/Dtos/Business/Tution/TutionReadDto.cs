using Entity.Dtos.Global;

namespace Entity.Dtos.Business.Tution
{
    public class TutionReadDto : ABaseDto
    {
        public int StudentId { get; set; }

        public string? FullName { get; set; }
        public string? FisrtName { get; set; }
        public string? SecondName { get; set; }
        public string? LastName { get; set; }
        public string? SecondLastName { get; set; }

        public int GradeId { get; set; }

        public string GradeName { get; set; }

    }
}
