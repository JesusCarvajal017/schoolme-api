using AutoMapper;
using Business.Implements.Bases;
using Business.Interfaces.Querys;
using Data.Interfaces.Group.Querys;
using Entity.Dtos.Business.AgendaDayStudent;
using Entity.Model.Business;
using Microsoft.Extensions.Logging;
using Utilities.Helpers.Validations;

namespace Business.Implements.Querys.Business
{
    public class AgendaDayStudentQueryBusiness : BaseQueryBusiness<AgendaDayStudent, AgendaDayStudentDto>, IQueryAgendaStudentDayServices
    {
        protected readonly IQuerysAgendaDayStudent _data;

        public AgendaDayStudentQueryBusiness(
            IQuerysAgendaDayStudent data,
            IMapper mapper,
            ILogger<AgendaDayStudentQueryBusiness> _logger,
            IGenericHerlpers helpers) : base(data, mapper, _logger, helpers)
        {
            _data = data;
        }

        public async Task<List<AgendaDayStudentListDto>> GetStudentsByAgendaDayAsync(
        int agendaDayId,
        CancellationToken ct = default)
        {
            var items = await _data.StudentsByAgendaDayAsync(agendaDayId, ct);
            return _mapper.Map<List<AgendaDayStudentListDto>>(items);
        }



    }
}
