using AutoMapper;
using Business.Implements.Bases;
using Business.Interfaces.Querys;
using Data.Interfaces.Group.Querys;
using Entity.Dtos.Business.Student;
using Entity.Dtos.Especific.DataBasicComplete;
using Entity.Model.Business;
using Entity.Model.Security;
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
