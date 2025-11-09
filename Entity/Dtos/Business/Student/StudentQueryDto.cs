using Entity.Dtos.Global;

namespace Entity.Dtos.Business.Student
{
    public class StudentQueryDto : ABaseDto
    {
        public int? PersonId { get; set; }
        public int? GroupId { get; set; }
        public string? GroupName { get; set; }

        public string? FullName { get; set; }
        public int? DocumentTypeId { get; set; }
        public string? AcronymDocument { get; set; }
        public long? Identification { get; set; }

    



    }
}
