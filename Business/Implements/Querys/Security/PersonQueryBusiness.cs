using AutoMapper;
using Business.Implements.Bases;
using Business.Interfaces.Querys;
using Data.Interfaces.Group.Querys;
using Entity.Dtos.Especific.DataBasicComplete;
using Entity.Dtos.Security.Person;
using Entity.Model.Security;
using Microsoft.Extensions.Logging;
using Utilities.Helpers.Validations;

namespace Business.Implements.Querys.Security
{
    public class PersonQueryBusiness : BaseQueryBusiness<Person, PersonQueryDto>, IQueryPersonServices
    {
        protected readonly IQuerysPerson _data;

        public PersonQueryBusiness(
            IQuerysPerson data,
            IMapper mapper,
            ILogger<PersonQueryBusiness> _logger,
            IGenericHerlpers helpers) : base(data, mapper, _logger, helpers)
        {
            _data = data;
        }

        public virtual async Task<CompleteDataPersonDto> GetDataCompleteServices(int id)
        {
            try
            {
                var person = await _data.QueryCompleteData(id);

                var dtoComplete = _mapper.Map<CompleteDataPersonDto>(person);

                _logger.LogInformation($"Obteniendo datos {typeof(Person).Name} con ID: {id}");
                return dtoComplete;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener datos {typeof(Person).Name} con ID {id}: {ex.Message}");
                throw;
            }
        }


        public virtual async Task<PersonCompleteReadDto> GetPersonDataBasic(int personId)
        {
            try
            {
                var entities = await _data.QueryById(personId);
                _logger.LogInformation($"Obteniendo {typeof(Person).Name} con ID: {personId}");
                return _mapper.Map<PersonCompleteReadDto>(entities);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener {typeof(Person).Name} con ID {personId}: {ex.Message}");
                throw;
            }
        }
    }
}
