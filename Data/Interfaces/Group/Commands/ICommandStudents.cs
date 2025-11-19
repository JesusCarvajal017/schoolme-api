using Entity.Dtos.Business.Student;
using Entity.Model.Business;

namespace Data.Interfaces.Group.Commands
{
    public interface ICommandStudents : ICommands<Student>
    {
        Task<bool> UpdateGrade(StudentsUpGrupDto dataUpdata);

    }
}
