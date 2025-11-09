using Entity.Dtos.Global;

namespace Entity.Dtos.Business.Attendants
{
    public class AttStudentsQueryDto : ABaseDto
    {
        public int? StudentId { get; set; }
        public string NameStudent { get; set; } 


        public int? AttendantId { get; set; }
        public string? NameAttendant { get; set; }
        public int RelationShipType { get; set; }

        public int? DocumentTypeId { get; set; }
        public string? AcronymDocument { get; set; }
        public long? Identification { get; set; }
    }
}
