using Entity.Dtos.Business.Student;
using Entity.Dtos.Especific.DataBasicComplete;
using Entity.Model.Business;

namespace Business.Interfaces.Querys
{
    public interface IQueryStudentServices : IQueryServices<Student, StudentQueryDto>
    {

        Task<CompleteDataPersonDto> GetDataCompleteServices(int id);
    }
}
