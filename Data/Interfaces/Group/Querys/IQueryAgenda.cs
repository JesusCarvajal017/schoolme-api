using Entity.Model.Business;

namespace Data.Interfaces.Group.Querys
{
    public interface IQueryAgenda : IQuerys<Agenda>
    {
        Task<Agenda> AgendaInfo(int agendaId);
    }
}
