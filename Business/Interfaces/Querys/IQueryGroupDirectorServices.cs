using Entity.Dtos.Business.GroupDirector;
using Entity.Model.Business;

namespace Business.Interfaces.Querys
{
    public interface IQueryGroupDirectorServices : IQueryServices<GroupDirector, GroupDirectorDto>
    {
        //Task<IEnumerable<MunicipalityDto>> GetMunicipalitysDepartament(int IdDepartament);
    }
}
