using AutoMapper;
using Business.Implements.Bases;
using Business.Interfaces.Querys;
using Data.Interfaces.Group.Querys;
using Entity.Dtos.Business.Student;
using Entity.Model.Business;
using Microsoft.Extensions.Logging;
using Utilities.Helpers.Validations;

namespace Business.Implements.Querys.Business
{
    public class StudentQueryBusiness : BaseQueryBusiness<Student, StudentQueryDto>, IQueryStudentServices
    {
        protected readonly IQuerysStudent _data;

        public StudentQueryBusiness(
            IQuerysStudent data,
            IMapper mapper,
            ILogger<StudentQueryBusiness> _logger,
            IGenericHerlpers helpers) : base(data, mapper, _logger, helpers)
        {
            _data = data;
        }

        public virtual async Task<StudentModelDto> GetDataCompleteServices(int id)
        {
            try
            {
                var person = await _data.QueryCompleteData(id);
                var dtoComplete = _mapper.Map<StudentModelDto>(person);

                _logger.LogInformation($"Obteniendo datos {typeof(Student).Name} con ID: {id}");

                return dtoComplete;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener datos {typeof(Student).Name} con ID {id}: {ex.Message}");
                throw;
            }
        }

        public virtual async Task<IEnumerable<StudentQueryDto>> GetNotMatriculados()
        {
            try
            {
                var person = await _data.QueryMatriculados();
                var dtoComplete = _mapper.Map<IEnumerable<StudentQueryDto>>(person);

                _logger.LogInformation($"Obteniendo datos {typeof(Student).Name}");

                return dtoComplete;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener datos {typeof(Student).Name} : {ex.Message}");
                throw;
            }

        }

        public virtual async Task<IEnumerable<StudentQueryDto>> GetStudentsGroup(int groudId)
        {
            try
            {
                var person = await _data.QueryStudentsGroup(groudId);
                var dtoComplete = _mapper.Map<IEnumerable<StudentQueryDto>>(person);

                _logger.LogInformation($"Obteniendo datos {typeof(Student).Name}");

                return dtoComplete;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener datos {typeof(Student).Name} : {ex.Message}");
                throw;
            }

        }


    }
}
