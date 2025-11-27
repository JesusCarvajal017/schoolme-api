using Entity.Model.Business;

namespace Data.Interfaces.Group.Querys
{

    public interface IQuerysAcademicLoad : IQuerys<AcademicLoad>
    {
        Task<IEnumerable<AcademicLoad>> QueryCargaAcademica(int idTeacher, int? status);
        Task<IEnumerable<AcademicLoad>> LoadTeacherDay(int idTeacher,int? status,int? day);
    }
}