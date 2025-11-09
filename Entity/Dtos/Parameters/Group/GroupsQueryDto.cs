using Entity.Dtos.Global;

namespace Entity.Dtos.Parameters.Group
{
    public class GroupsQueryDto : ABaseDto
    {
        public string? Name { get; set; }
        public int? GradeId { get; set; }
        public string? GradeName { get; set; }
        public int? AmountStudents { get; set; }
        public int? AgendaId { get; set; }
    }

}
