using AutoMapper;
using Business.Implements.Bases;
using Business.Interfaces.Querys;
using Data.Interfaces.Group.Querys;
using Entity.Dtos.Business.GroupDirector;
using Entity.Dtos.Parameters.Group;
using Entity.Model.Business;
using Microsoft.Extensions.Logging;
using Utilities.Helpers.Validations;

namespace Business.Implements.Querys.Business
{
    public class GroupDirectorQueryBusiness : BaseQueryBusiness<GroupDirector, GroupDirectorDto>, IQueryGroupDirectorServices
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


        public override async Task<IEnumerable<GroupDirectorDto>> GetAllServices(int? status)
        {
            try
            {
                var entities = await _data.QueryAllAsyn(status);
                _logger.LogInformation($"Obteniendo todos los registros de {typeof(GroupDirector).Name}");
                return _mapper.Map<IEnumerable<GroupDirectorDto>>(entities);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener registros de {typeof(GroupDirector).Name}: {ex.Message}");
                throw;
            }
        }



    }
}
