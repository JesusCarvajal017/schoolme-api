using AutoMapper;
using Business.Implements.Bases;
using Business.Interfaces.Querys;
using Data.Interfaces.Group.Querys;
using Entity.Dtos.Business.Tution;
using Entity.Model.Business;
using Microsoft.Extensions.Logging;
using Utilities.Helpers.Validations;

namespace Business.Implements.Querys.Business
{
    public class TutitionQueryBusiness : BaseQueryBusiness<Tutition, TutionReadDto>, IQueryTutitionServices
    {
        protected readonly IQuerysTutition _data;

        public TutitionQueryBusiness(
            IQuerysTutition data,
            IMapper mapper,
            ILogger<TutitionQueryBusiness> _logger,
            IGenericHerlpers helpers) : base(data, mapper, _logger, helpers)
        {
            _data = data;
        }


        public virtual async Task<IEnumerable<TutionReadDto>> GetTutitionGrade(int gradeId)
        {
            try
            {
                var entities = await _data.QueryTutitionGrade(gradeId);
                _logger.LogInformation($"Obteniendo todos los registros de {typeof(TutionReadDto).Name}");
                return _mapper.Map<IEnumerable<TutionReadDto>>(entities);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener registros de {typeof(TutionReadDto).Name}: {ex.Message}");
                throw;
            }
        }



    }
}
