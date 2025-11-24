using Entity.Model.Paramters;

namespace Data.Interfaces.Group.Querys
{

    /// <summary>
    /// Interfaz de extension de user rol
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IQuerysGrups : IQuerys<Groups>
    {
        Task<IEnumerable<Groups>> QueryGrupsGrade(int gradeId);

        //Task<IEnumerable<Groups>> QueryAgendaGroups(int gradeId, int agendaId);

    }
}