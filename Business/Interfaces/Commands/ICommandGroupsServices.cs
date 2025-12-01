using Business.Interfaces.Commands;
using Entity.Dtos.Parameters.Group;
using Entity.Model.Paramters;

namespace Business.Interfaces.Querys
{
    public interface ICommandGroupsServices : ICommandService<Groups, GroupsDto>
    {
        Task<bool> ChangeAgendaServies(int id, int? agendaId);
    }
}
