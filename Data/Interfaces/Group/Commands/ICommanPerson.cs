using Entity.Model.Security;

namespace Data.Interfaces.Group.Commands
{
    public interface ICommanPerson : ICommands<Person>
    {
        Task<Person> InsertComplete(Person current);
        Task<Person> UpdateCompleteAsync(Person trackedEntity);
        Task<Person?> QueryByIdTrackedAsync(int id);
    }
}
