using AutoMapper;
using Business.Implements.Bases;
using Business.Interfaces.Querys;
using Data.Interfaces.Group.Querys;
using Entity.Dtos.Business.AcademicLoad;
using Entity.Model.Business;
using Microsoft.Extensions.Logging;
using Utilities.Helpers.Validations;

namespace Business.Implements.Querys.Business
{
    public class AcLoadQueryBusiness : BaseQueryBusiness<AcademicLoad, AcademicLoadReadDto>, IQueryAcLoadServices
    {
        protected readonly IQuerysAcademicLoad _data;

        public AcLoadQueryBusiness(
            IQuerysAcademicLoad data,
            IMapper mapper,
            ILogger<AcLoadQueryBusiness> _logger,
            IGenericHerlpers helpers) : base(data, mapper, _logger, helpers)
        {
            _data = data;
        }

        public override async Task<IEnumerable<AcademicLoadReadDto>> GetAllServices(int? status)
        {
            try
            {
                var entities = await _data.QueryAllAsyn(status);
                _logger.LogInformation($"Obteniendo todos los registros de {typeof(AcademicLoad).Name}");
                return _mapper.Map<IEnumerable<AcademicLoadReadDto>>(entities);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener registros de {typeof(AcademicLoad).Name}: {ex.Message}");
                throw;
            }
        }

        public virtual async Task<IEnumerable<AcademicLoadReadDto>> GetTeacherLoad(int idTeacher,int? status)
        {
            try
            {
                var entities = await _data.QueryCargaAcademica(idTeacher,status);
                _logger.LogInformation($"Obteniendo todos los registros de {typeof(AcademicLoad).Name}");
                return _mapper.Map<IEnumerable<AcademicLoadReadDto>>(entities);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener registros de {typeof(AcademicLoad).Name}: {ex.Message}");
                throw;
            }
        }


        public virtual async Task<IEnumerable<LoadByDayReadDto>> GetTeacherLoadDay(
            int idTeacher,
            int? status,
            int? day // NUEVO
        )
        {
            try
            {
                var entities = await _data.LoadTeacherDay(idTeacher, status, day);
                _logger.LogInformation($"Obteniendo todos los registros de {typeof(AcademicLoad).Name}");

                return _mapper.Map<IEnumerable<LoadByDayReadDto>>(entities);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener registros de {typeof(AcademicLoad).Name}: {ex.Message}");
                throw;
            }
        }




    }
}
