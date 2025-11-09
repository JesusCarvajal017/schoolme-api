using Entity.Dtos.Global;

namespace Entity.Dtos.Business.GroupDirector
{
    public class GroupDirectorDto : ABaseDto
    {
        public int? TeacherId { get; set; } // FK hacia Teacher
   

        public int? GroupId { get; set; }


    }
}
