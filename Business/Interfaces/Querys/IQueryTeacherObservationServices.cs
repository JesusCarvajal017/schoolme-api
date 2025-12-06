using Entity.Dtos.Business.TeacherObservation;
using Entity.Model.Business;
namespace Business.Interfaces.Querys
{
    public interface IQueryTeacherObservationServices : IQueryServices<TeacherObservation, TeacherObservationDto>
    {
        Task<TeacherObservationDto> GetObservationStudent(int agendaDayStudentId, int academicLoadId, CancellationToken ct = default);
        Task<List<TeacherObservationQueryDto>> GetByAgendaDayStudentService(
        int agendaDayStudentId,
        CancellationToken ct = default);

    }
}
