using AutoMapper;
using Business.Implements.Bases;
using Business.Interfaces.Querys;
using Data.Interfaces.Group.Querys;
using Entity.Dtos.Business.Teacher;
using Entity.Dtos.Especific.DataBasicComplete;
using Entity.Model.Business;
using Entity.Model.Security;
using Microsoft.Extensions.Logging;
using Utilities.Helpers.Validations;

namespace Business.Implements.Querys.Business
{
    public class TeacherQueryBusiness : BaseQueryBusiness<Teacher, TeacherReadDto>, IQueryTeacherServices
    {
        protected readonly IQueryTeacher _data;

        public TeacherQueryBusiness(
            IQueryTeacher data,
            IMapper mapper,
            ILogger<TeacherQueryBusiness> _logger,
            IGenericHerlpers helpers) : base(data, mapper, _logger, helpers)
        {
            _data = data;
        }

        public virtual async Task<TeacherModelDto> GetDataCompleteServices(int id)
        {
            try
            {
                var person = await _data.QueryCompleteData(id);

                var dtoComplete = _mapper.Map<TeacherModelDto>(person);

                _logger.LogInformation($"Obteniendo datos {typeof(CompleteDataPersonDto).Name} con ID: {id}");
                return dtoComplete;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener datos {typeof(CompleteDataPersonDto).Name} con ID {id}: {ex.Message}");
                throw;
            }
        }




    }
}
