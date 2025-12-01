using Entity.Model.Business;

namespace Data.Interfaces.Group.Querys
{
    public interface IQueryTeacherObservation : IQuerys<TeacherObservation>
    {
        Task<TeacherObservation> QueryObservationStudent(int agendaStudentDayId);
    }
}
