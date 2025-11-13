using Entity.Dtos.Business.Teacher;
using Entity.Model.Business;

namespace Business.Interfaces.Querys
{
    public interface IQueryTeacherServices : IQueryServices<Teacher, TeacherReadDto>
    {

        Task<TeacherModelDto> GetDataCompleteServices(int id);
    }
}
