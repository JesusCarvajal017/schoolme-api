using Entity.Dtos.Business.Student;
using Entity.Model.Business;

namespace Business.Interfaces.Querys
{
    public interface IQueryStudentServices : IQueryServices<Student, StudentQueryDto>
    {

        Task<StudentModelDto> GetDataCompleteServices(int id);

        Task<IEnumerable<StudentQueryDto>> GetNotMatriculados();

        Task<IEnumerable<StudentQueryDto>> GetStudentsGroup(int groudId);


    }
}
