using Entity.Dtos.Business.GroupDirector;
using Entity.Model.Business;

namespace Business.Interfaces.Querys
{
    public interface IQueryGroupDirectorServices : IQueryServices<GroupDirector, GroupDirectorQueryDto>
    {
        //Task<IEnumerable<MunicipalityDto>> GetMunicipalitysDepartament(int IdDepartament);
        Task<IEnumerable<GroupsDirectorQueryDto>> GetGroupsDirect(int teacherId);
    }
}
