using Entity.Model.Security;

namespace Data.Interfaces.Group.Querys
{

    /// <summary>
    /// Interfaz de extension de user rol
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IQuerysPerson : IQuerys<Person>
    {
        Task<Person> QueryCompleteData(int personId);

    }



}