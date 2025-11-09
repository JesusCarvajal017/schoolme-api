using Entity.Model.Global;
using Entity.Model.Paramters;

namespace Entity.Model.Business
{
    public class GroupDirector : ABaseEntity
    {
    
        public int TeacherId { get; set; } // FK hacia Teacher
        public int GroupId { get; set; }

        public Teacher Teacher { get; set; }
        public Groups Groups { get; set; }


    }
}
