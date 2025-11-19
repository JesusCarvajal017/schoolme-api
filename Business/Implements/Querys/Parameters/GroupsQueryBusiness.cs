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




    }
}
