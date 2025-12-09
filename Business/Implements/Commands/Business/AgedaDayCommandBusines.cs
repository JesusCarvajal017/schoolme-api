
using AutoMapper;
using Business.Implements.Bases;
using Business.Interfaces.Querys;
using Business.Interfaces.SingalR;
using Data.Interfaces.Group.Commands;
using Entity.Context.Main;
using Entity.Dtos.Business.AgendaDay;
using Entity.Model.Business;
using Microsoft.Extensions.Logging;
using Utilities.Helpers.Validations;

namespace Business.Implements.Commands.Business
{
    public class AgedaDayCommandBusines : BaseCommandsBusiness<AgendaDay, AgendaDayDto>, ICommandAgedaDayServices
    {
        protected readonly ICommanAgendaDay _data;
        private readonly IAgendaDayRealtimeService _realtime;

        public AgedaDayCommandBusines(
            ICommanAgendaDay data,
            IMapper mapper,
            ILogger<AgedaDayCommandBusines> _logger,
            IGenericHerlpers helpers,
            AplicationDbContext context,
            IAgendaDayRealtimeService realtime
            ) : base(data, mapper, _logger, helpers, context)
        {
            _data = data;
            _realtime = realtime;
        }




        public override async Task<AgendaDayDto> CreateServices(AgendaDayDto dto)
        {
            try
            {
                await EnsureValid(dto);
                var entity = _mapper.Map<AgendaDay>(dto);
                entity = await _data.InsertAsync(entity);
                _logger.LogInformation($"Creando nuevo {typeof(AgendaDay).Name}");
                return _mapper.Map<AgendaDayDto>(entity);
            }
            catch (Exception ex)
            {
                //_logger.LogError($"Error al crear {typeof(T).Name} desde DTO: {ex.Message}");
                throw;
            }
        }

        public async Task CloseAsync(int agendaDayId, CancellationToken ct = default)
        {
            var entity = await _data.GetByIdAsync(agendaDayId, ct);

            if (entity is null)
            {
                _logger.LogWarning("Intento de cierre de AgendaDay {Id} que no existe", agendaDayId);
                throw new KeyNotFoundException($"AgendaDay {agendaDayId} no existe");
            }

            // si ya está cerrada, no hacemos nada
            // el estado que decide si colocarle null
            if (entity.ClosedAt != null)
            {
                _logger.LogInformation("AgendaDay {Id} ya estaba cerrada", agendaDayId);
                return;
            }

            entity.ClosedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;
            // si usas Status para algo:
            // entity.Status = (int)AgendaDayStateEnum.Closed;

            await _data.SaveChangesAsync(ct);
            await _realtime.PublishTodayListAsync(ct);

            _logger.LogInformation("AgendaDay {Id} cerrada correctamente", agendaDayId);
        }

        public async Task ReopenAgendaDayAsync(int agendaDayId, CancellationToken ct = default)
        {
            _logger.LogInformation("Reabriendo AgendaDay {AgendaDayId}", agendaDayId);

            await _data.ReopenAgendaDayAsync(agendaDayId, ct);

            await _realtime.PublishTodayListAsync(ct);
        }





    }
}
