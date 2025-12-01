using Entity.Dtos.Global;
using Entity.Dtos.Security.Person;

namespace Entity.Dtos.Business.Teacher
{
    public class TeacherModelDto : ABaseDto
    {
        public int? PersonId { get; set; }
        public PersonCompleteDto Person { get; set; }
    }
}
