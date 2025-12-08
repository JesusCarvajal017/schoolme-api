using AutoMapper;
using Business.Implements.Bases;
using Business.Interfaces.Querys;
using Data.Interfaces.Group.Querys;
using Entity.Dtos.Business.AgendaDay;
using Entity.Dtos.Business.AgendaDayStudent;
using Entity.Enum;
using Entity.Model.Business;
using Microsoft.Extensions.Logging;
using Utilities.Helpers.Validations;

namespace Business.Implements.Querys.Business
{
    public class AgendaDayQueryBusiness : BaseQueryBusiness<AgendaDay, AgendaDayDto>, IQueryAgendaDayServices
    {
        protected readonly IQuerysAgendaDay _data;

        public AgendaDayQueryBusiness(
            IQuerysAgendaDay data,
            IMapper mapper,
            ILogger<AgendaDayQueryBusiness> _logger,
            IGenericHerlpers helpers) : base(data, mapper, _logger, helpers)
        {
            _data = data;
        }

        public async Task<List<AgendaDayAdminListDto>> GetTodayAgendaDaysAsync(
            CancellationToken ct = default)
        {
            var today = DateOnly.FromDateTime(DateTime.Now);

            var entities = await _data.GetByDateAsync(today, ct);

            var dtos = _mapper.Map<List<AgendaDayAdminListDto>>(entities);

            // calcular el estado según ClosedAt / OpenedAt
            for (int i = 0; i < entities.Count; i++)
            {
                var e = entities[i];
                var dto = dtos[i];

                dto.State = e.ClosedAt switch
                {
                    not null => AgendaDayStateEnum.Closed,
                    null => AgendaDayStateEnum.Open
                };
            }

            return dtos;
        }


    }
}
