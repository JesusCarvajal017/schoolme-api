using Entity.Model.Global;
using Entity.Model.Paramters;
using Entity.Model.Security;

namespace Entity.Model.Business
{
    public class Student : ABaseEntity
    {
        public int PersonId { get; set; }
        public int? GroupId { get; set; } = null!;
        
        public Person Person { get; set; }
        public ICollection<AgendaDayStudent> AgendaDayStudents { get; set; } = new List<AgendaDayStudent>();
        public ICollection<Attendants> Attendants { get; set; }
        public Groups? Groups { get; set; }
        public IEnumerable<Tutition> Tutition { get; private set; }

    }
}
