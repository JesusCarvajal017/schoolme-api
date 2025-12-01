using Entity.Model.Paramters;

namespace Data.Interfaces.Group.Commands
{
    public interface ICommadGroups : ICommands<Groups>
    {
        Task<bool> UpdateAgendaAsync(int id, int? agendaId);
    }
}
