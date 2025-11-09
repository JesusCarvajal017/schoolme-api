using Entity.Dtos.Business.AcademicLoad;
using Entity.Model.Business;

namespace Business.Interfaces.Querys
{
    public interface IQueryAcLoadServices : IQueryServices<AcademicLoad, AcademicLoadReadDto>
    {
        Task<IEnumerable<AcademicLoadReadDto>> GetTeacherLoad(int IdUser, int? status);
    }
}
