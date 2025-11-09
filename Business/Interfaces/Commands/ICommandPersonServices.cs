using Business.Interfaces.Commands;
using Entity.Dtos.Security.Person;
using Entity.Model.Security;

namespace Business.Interfaces.Querys
{
    public interface ICommandPersonServices : ICommandService<Person, PersonDto>
    {
        Task<PersonCompleteDto> CreateRemastered(PersonCompleteDto current, int? rolId);

        Task<PersonCompleteDto> UpdateRemasteredAsync(int id, PersonCompleteDto dto);

    }
}
