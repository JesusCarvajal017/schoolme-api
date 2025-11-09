using Entity.Dtos.Business.Attendants;
using Entity.Model.Business;

namespace Business.Interfaces.Querys
{
    public interface IQueryAttendansServices : IQueryServices<Attendants, AttQueryDto>
    {
        Task<IEnumerable<AttendantsQueryDto>> GetRelationServices(int? status, int personId);
        Task<IEnumerable<AttStudentsQueryDto>> GetRelationStudentsServices(int? status, int personId);
    }
}
