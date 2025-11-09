using Entity.Model.Global;

namespace Entity.Model.Business
{
    public class TeacherObservation : ABaseEntity
    {

        public int TeacherId { get; set; }
        public int AgendaDayStudentId {  get; set; }
        public string Text { get; set; }

        public Teacher Teacher { get; set; }
        public AgendaDayStudent AgendaDayStudent { get; set; }
    }
}
