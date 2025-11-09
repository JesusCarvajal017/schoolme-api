using Entity.Dtos.Global;

namespace Entity.Dtos.Business.AcademicLoad
{
    public class AcademicLoadReadDto : ABaseDto
    {
        public int? TeacherId { get; set; }
        
        public string FullName { get; set; }

        public int? SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int? GroupId { get; set; }
        public string GroupName { get; set; }

        //public int Day
        public string[] Days { get; set; } = [];
    }
}
