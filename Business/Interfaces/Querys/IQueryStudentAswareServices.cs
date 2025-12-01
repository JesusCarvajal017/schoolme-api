using Entity.Dtos.Business.StudentAnsware;
using Entity.Dtos.Business.StudentAnswareOption;
using Entity.Model.Business;

namespace Business.Interfaces.Querys
{
    public interface IQueryStudentAswareServices : IQueryServices<StudentAnswer, StudentAnswareDto>
    {
        Task<RegisterStudentAnswersDto> GetAnswersAsync(
            int agendaDayStudentId,
            CancellationToken ct = default);
    }
}
