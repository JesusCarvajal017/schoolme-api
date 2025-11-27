using Business.Interfaces.Commands;
using Entity.Dtos.Business.StudentAnsware;
using Entity.Dtos.Business.StudentAnswareOption;
using Entity.Model.Business;

namespace Business.Interfaces.Querys
{
    public interface ICommandStAswareServices : ICommandService<StudentAnswer, StudentAnswareDto>
    {
        Task RegisterAnswersAsync(RegisterStudentAnswersDto dto, CancellationToken ct = default);

        Task UpdateAnswersAsync(RegisterStudentAnswersDto dto, CancellationToken ct = default);
    }
}
