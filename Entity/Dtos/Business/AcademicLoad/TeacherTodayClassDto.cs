using Entity.Enum;

namespace Entity.Dtos.Business.AcademicLoad
{
    public class TeacherTodayClassDto
    {
        public int AcademicLoadId { get; set; }

        public string SubjectName { get; set; } = null!;
        public string GroupName { get; set; } = null!;
        public string GradeName { get; set; } = null!;

        public int GroupId { get; set; }

        public int? AgendaDayId { get; set; }
        public AgendaDayStateEnum AgendaState { get; set; } = AgendaDayStateEnum.NotInitialized;
    }
}
