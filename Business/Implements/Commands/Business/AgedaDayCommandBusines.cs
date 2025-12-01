using AutoMapper;
using Business.Implements.Bases;
using Business.Interfaces.Querys;
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

        public AgedaDayCommandBusines(
            ICommanAgendaDay data,
            IMapper mapper,
            ILogger<AgedaDayCommandBusines> _logger,
            IGenericHerlpers helpers,
            AplicationDbContext context
            ) : base(data, mapper, _logger, helpers, context)
        {
            _data = data;
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

            _logger.LogInformation("AgendaDay {Id} cerrada correctamente", agendaDayId);
        }



    }
}
