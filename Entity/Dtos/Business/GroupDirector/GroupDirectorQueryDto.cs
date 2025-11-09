using Entity.Dtos.Global;

namespace Entity.Dtos.Business.GroupDirector
{
    public class GroupDirectorQueryDto : ABaseDto
    {
        public int? TeacherId { get; set; } // FK hacia Teacher

        public string? FullName { get; set; }
        public string? FisrtName { get; set; }
        public string? SecondName { get; set; }
        public string? LastName { get; set; }
        public string? SecondLastName { get; set; }

        public int? GroupId { get; set; }
        public string NameGroup { get; set; }

    }
}
