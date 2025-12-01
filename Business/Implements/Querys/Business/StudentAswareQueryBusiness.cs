using AutoMapper;
using Business.Implements.Bases;
using Business.Interfaces.Querys;
using Data.Interfaces.Group.Querys;
using Entity.Dtos.Business.StudentAnsware;
using Entity.Dtos.Business.StudentAnswareOption;
using Entity.Model.Business;
using Microsoft.Extensions.Logging;
using Utilities.Helpers.Validations;

namespace Business.Implements.Querys.Business
{
    public class StudentAswareQueryBusiness : BaseQueryBusiness<StudentAnswer, StudentAnswareDto>, IQueryStudentAswareServices
    {
        protected readonly IQueryStudentAsware _data;

        public StudentAswareQueryBusiness(
            IQueryStudentAsware data,
            IMapper mapper,
            ILogger<StudentAswareQueryBusiness> _logger,
            IGenericHerlpers helpers) : base(data, mapper, _logger, helpers)
        {
            _data = data;
        }


        public async Task<RegisterStudentAnswersDto> GetAnswersAsync(
           int agendaDayStudentId,
           CancellationToken ct = default)
            {
                var entities = await _data.GetAnswersByAgendaDayStudentAsync(agendaDayStudentId, ct);

                var answersDto = _mapper.Map<List<StudentAnswerInputDto>>(entities);

                return new RegisterStudentAnswersDto
                {
                    AgendaDayStudentId = agendaDayStudentId,
                    Answers = answersDto
                };
            }


    }
}
