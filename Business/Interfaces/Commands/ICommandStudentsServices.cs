using Business.Interfaces.Commands;
using Entity.Dtos.Business.Student;
using Entity.Model.Business;

namespace Business.Interfaces.Querys
{
    public interface ICommandStudentsServices : ICommandService<Student, StudentDto>
    {
 
        Task<bool> ChangeGrupServices(StudentsUpGrupDto dataUpdate);
    
    }
}
