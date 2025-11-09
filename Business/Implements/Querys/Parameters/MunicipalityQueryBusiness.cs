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
    public class MunicipalityQueryBusiness : BaseQueryBusiness<Munisipality, MunicipalityQueryDto>, IQueryMunicipalityServices
    {
        protected readonly IQuerysMunicipality _data;

        public MunicipalityQueryBusiness(
            IQuerysMunicipality data,
            IMapper mapper,
            ILogger<MunicipalityQueryBusiness> _logger,
            IGenericHerlpers helpers) : base(data, mapper, _logger, helpers)
        {
            _data = data;
        }

        public async Task<IEnumerable<MunicipalityDto>> GetMunicipalitysDepartament(int IdDepartament)
        {
            try
            {
                var entities = await _data.QueryMunicpalitysDepartaments(IdDepartament);

                _logger.LogInformation($"Obteniendo los municipios");

                var result = _mapper.Map<IEnumerable<MunicipalityDto>>(entities);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener al obtener los municipios del departamento con el id {IdDepartament}");
                throw;
            }
        }




    }
}
