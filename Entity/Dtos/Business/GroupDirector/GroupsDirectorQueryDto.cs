using Entity.Dtos.Global;
using Entity.Enum;

namespace Entity.Dtos.Business.GroupDirector
{
    public class GroupsDirectorQueryDto : ABaseDto
    {
        public int? TeacherId { get; set; } // FK hacia Teacher
        public int? GroupId { get; set; }
        public int? AgendaId { get; set; }
        public string NameGroup { get; set; }

        public string NameGrade { get; set; }

        public int AmountStudents { get; set; }
        public int? AgendaDayId { get; set; }  // AgendaDay del día de hoy

        public AgendaDayStateEnum AgendaState { get; set; }


    }
}
