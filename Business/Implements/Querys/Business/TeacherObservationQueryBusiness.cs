using AutoMapper;
using Business.Implements.Bases;
using Business.Interfaces.Querys;
using Data.Interfaces.Group.Querys;
using Entity.Dtos.Business.TeacherObservation;
using Entity.Model.Business;
using Microsoft.Extensions.Logging;
using Utilities.Helpers.Validations;

namespace Business.Implements.Querys.Business
{
    public class TeacherObservationQueryBusiness : BaseQueryBusiness<TeacherObservation,TeacherObservationDto >, IQueryTeacherObservationServices
    {
        protected readonly IQueryTeacherObservation _data;

        public TeacherObservationQueryBusiness(
            IQueryTeacherObservation data,
            IMapper mapper,
            ILogger<TeacherObservationQueryBusiness> _logger,
            IGenericHerlpers helpers) : base(data, mapper, _logger, helpers)
        {
            _data = data;
        }


        public virtual async Task<TeacherObservationDto> GetObservationStudent(int agendaDayStudentId)
        {
            try
            {
                var entities = await _data.QueryObservationStudent(agendaDayStudentId);
                _logger.LogInformation($"Obteniendo todos los registros de {typeof(TeacherObservationDto).Name}");
                return _mapper.Map<TeacherObservationDto>(entities);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener registros de {typeof(TeacherObservationDto).Name}: {ex.Message}");
                throw;
            }
        }



    }
}
