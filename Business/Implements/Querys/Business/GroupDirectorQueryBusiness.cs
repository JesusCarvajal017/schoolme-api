using AutoMapper;
using Business.Implements.Bases;
using Business.Interfaces.Querys;
using Data.Interfaces.Group.Querys;
using Entity.Dtos.Business.GroupDirector;
using Entity.Dtos.Parameters.Group;
using Entity.Enum;
using Entity.Model.Business;
using Microsoft.Extensions.Logging;
using Utilities.Helpers.Validations;

namespace Business.Implements.Querys.Business
{
    public class GroupDirectorQueryBusiness : BaseQueryBusiness<GroupDirector, GroupDirectorQueryDto>, IQueryGroupDirectorServices
    {
        protected readonly IQuerysGroupDirector _data;

        public GroupDirectorQueryBusiness(
            IQuerysGroupDirector data,
            IMapper mapper,
            ILogger<GroupDirectorQueryBusiness> _logger,
            IGenericHerlpers helpers) : base(data, mapper, _logger, helpers)
        {
            _data = data;
        }


        public override async Task<IEnumerable<GroupDirectorQueryDto>> GetAllServices(int? status)
        {
            try
            {
                var entities = await _data.QueryAllAsyn(status);
                _logger.LogInformation($"Obteniendo todos los registros de {typeof(GroupDirector).Name}");
                return _mapper.Map<IEnumerable<GroupDirectorQueryDto>>(entities);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener registros de {typeof(GroupDirector).Name}: {ex.Message}");
                throw;
            }
        }

        public virtual async Task<IEnumerable<GroupsDirectorQueryDto>> GetGroupsDirect(int teacherId)
        {
            try
            {
                var entities = await _data.GroupsDirector(teacherId);
                _logger.LogInformation($"Obteniendo todos los registros de {typeof(GroupDirector).Name}");

                var dtos = _mapper.Map<List<GroupsDirectorQueryDto>>(entities);

                var today = DateOnly.FromDateTime(DateTime.Now); // o DateTime.UtcNow si quieres UTC

                // sincronizar lógica de AgendaDay de HOY
                foreach (var dto in dtos)
                {
                    // buscar la entidad GroupDirector correspondiente
                    var entity = entities.First(e => e.Id == dto.Id);

                    // de ese grupo, buscamos la AgendaDay del día de hoy
                    var todayAgenda = entity.Groups.AgendaDay
                        .FirstOrDefault(ad => ad.Date == today);

                    if (todayAgenda is null)
                    {
                        dto.AgendaDayId = null;
                        dto.AgendaState = 0; // sin agenda del día
                    }
                    else
                    {
                        dto.AgendaDayId = todayAgenda.Id;

                        // aquí puedes poner tu propia lógica de estado
                        // ejemplo simple:
                        // 1 = abierta, 2 = cerrada
                        if (todayAgenda.ClosedAt != null)
                            dto.AgendaState = AgendaDayStateEnum.Closed;
                        else
                            dto.AgendaState = AgendaDayStateEnum.Open;
                    }
                }

                return dtos;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener registros de {typeof(GroupDirector).Name}: {ex.Message}");
                throw;
            }
        }





    }
}
