using AutoMapper;
using Business.Implements.Bases;
using Business.Interfaces.Querys;
using Data.Interfaces.Group.Querys;
using Entity.Dtos.Parameters.Group;
using Entity.Model.Paramters;
using Microsoft.Extensions.Logging;
using Utilities.Helpers.Validations;

namespace Business.Implements.Querys.Security
{
    public class GroupsQueryBusiness : BaseQueryBusiness<Groups, GroupsQueryDto>, IQueryGrupsServices
    {
        protected readonly IQuerysGrups _data;

        public GroupsQueryBusiness(
            IQuerysGrups data,
            IMapper mapper,
            ILogger<GroupsQueryBusiness> _logger,
            IGenericHerlpers helpers) : base(data, mapper, _logger, helpers)
        {
            _data = data;
        }

        public async Task<IEnumerable<GroupsQueryDto>> GetGrupsGrade(int gradeId)
        {
            try
            {
                var entities = await _data.QueryGrupsGrade(gradeId);

                _logger.LogInformation($"Obteniendo los municipios");

                var result = _mapper.Map<IEnumerable<GroupsQueryDto>>(entities);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener al obtener los grupos del grado con el id {gradeId}");
                throw;
            }
        }

        public async Task<IEnumerable<GroupsAgendaDto>> GetGroupsAgendas(int gradeId, int agendaId)
        {
            try
            {
                // Se optiene los grupos segun el grado
                var entities = await _data.QueryGrupsGrade(gradeId);

                // map normal
                var dtos = _mapper.Map<List<GroupsAgendaDto>>(entities);

                // lógica de negocio: marcar si el grupo tiene esta agenda
                foreach (var dto in dtos)
                {
                    var entity = entities.First(g => g.Id == dto.Id);
                    dto.IsAssigned = entity.AgendaId == agendaId;
                }

                _logger.LogInformation(
                    "Obteniendo grupos de grado {GradeId} para agenda {AgendaId}",
                    gradeId, agendaId);

                return dtos;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener los grupos con las agendas relacionadas: {gradeId}");
                throw;
            }
        }




    }
}
