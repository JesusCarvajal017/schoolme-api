using Entity.Dtos.Especific.DataBasicComplete;
using Entity.Dtos.Security.Person;
using Entity.Model.Security;

namespace Business.Interfaces.Querys
{
    public interface IQueryPersonServices : IQueryServices<Person, PersonQueryDto>
    {
        Task<CompleteDataPersonDto> GetDataCompleteServices(int personId);
        Task<PersonCompleteReadDto> GetPersonDataBasic(int personId);
    }
}
