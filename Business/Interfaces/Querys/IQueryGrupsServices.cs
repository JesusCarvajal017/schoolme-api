using Entity.Dtos.Parameters.Group;
using Entity.Model.Paramters;

namespace Business.Interfaces.Querys
{
    public interface IQueryGrupsServices : IQueryServices<Groups, GroupsQueryDto>
    {
        Task<IEnumerable<GroupsQueryDto>> GetGrupsGrade(int gradeId);

        Task<IEnumerable<GroupsAgendaDto>> GetGroupsAgendas(int gradeId, int agendaId);


    }
}
