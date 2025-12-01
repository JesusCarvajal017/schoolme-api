using Entity.Dtos.Global;

namespace Entity.Dtos.Parameters.Group
{
    public class GroupsWirteDto : ABaseDto
    {
        public string? Name { get; set; }
        public int? GradeId { get; set; }
        public int? AmountStudents { get; set; }
        public int? AgendaId { get; set; }
    }

}
