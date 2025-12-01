using AutoMapper;
using Business.Implements.Bases;
using Business.Interfaces.Querys;
using Data.Interfaces.Group.Querys;
using Entity.Dtos.Business.Attendants;
using Entity.Dtos.Especific.DataBasicComplete;
using Entity.Model.Business;
using Entity.Model.Security;
using Microsoft.Extensions.Logging;
using Utilities.Helpers.Validations;

namespace Business.Implements.Querys.Business
{
    public class AttendansQueryBusiness : BaseQueryBusiness<Attendants, AttQueryDto>, IQueryAttendansServices
    {
        protected readonly IQuerysAttendas _data;

        public AttendansQueryBusiness(
            IQuerysAttendas data,
            IMapper mapper,
            ILogger<AttendansQueryBusiness> _logger,
            IGenericHerlpers helpers) : base(data, mapper, _logger, helpers)
        {
            _data = data;
        }


        public override async Task<IEnumerable<AttQueryDto>> GetAllServices(int? status)
        {
            try
            {
                var entities = await _data.QueryAllAsyn(status);
                _logger.LogInformation($"Obteniendo todos los registros de {typeof(AttQueryDto).Name}");
                return _mapper.Map<IEnumerable<AttQueryDto>>(entities);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener registros de {typeof(AttQueryDto).Name}: {ex.Message}");
                throw;
            }
        }



        public virtual async Task<IEnumerable<AttendantsQueryDto>> GetRelationServices(int? status, int personId)
        {
            try
            {
                var entities = await _data.QueryRelations(status, personId);
                _logger.LogInformation($"Obteniendo todos los registros de {typeof(Attendants).Name}");
                return _mapper.Map<IEnumerable<AttendantsQueryDto>>(entities);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener registros de {typeof(Attendants).Name}: {ex.Message}");
                throw;
            }
        }


        public virtual async Task<IEnumerable<AttStudentsQueryDto>> GetRelationStudentsServices(int? status, int personId)
        {
            try
            {
                var entities = await _data.QueryRelationsStudents(status, personId);
                _logger.LogInformation($"Obteniendo todos los registros de {typeof(Attendants).Name}");
                return _mapper.Map<IEnumerable<AttStudentsQueryDto>>(entities);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener registros de {typeof(Attendants).Name}: {ex.Message}");
                throw;
            }
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




    }
}
