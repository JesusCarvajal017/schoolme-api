using Entity.Dtos.Business.Tution;
using Entity.Model.Business;

namespace Business.Interfaces.Querys
{
    public interface IQueryTutitionServices : IQueryServices<Tutition, TutionReadDto>
    {
        Task<IEnumerable<TutionReadDto>> GetTutitionGrade(int gradeId);
    }
}
