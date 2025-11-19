using Entity.Dtos.Global;
using Entity.Dtos.Security.Person;

namespace Entity.Dtos.Business.Student
{
    public class StudentModelDto : ABaseDto
    {
        public int? PersonId { get; set; }
        public int? GroupId { get; set; }

        public PersonCompleteDto Person { get; set; }
    }
}
