using AutoMapper;
using Business.Implements.Bases;
using Business.Interfaces.Querys;
using Data.Interfaces.Group.Querys;
using Entity.Context.Main;
using Entity.Dtos.Business.TeacherObservation;
using Entity.Model.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Utilities.Helpers.Validations;

namespace Business.Implements.Querys.Business
{
    public class TeacherObservationQueryBusiness : BaseQueryBusiness<TeacherObservation,TeacherObservationDto >, IQueryTeacherObservationServices
    {
        protected readonly IQueryTeacherObservation _data;
        private readonly AplicationDbContext _context;

        public TeacherObservationQueryBusiness(
            AplicationDbContext context,
            IQueryTeacherObservation data,
            IMapper mapper,
            ILogger<TeacherObservationQueryBusiness> _logger,
            IGenericHerlpers helpers) : base(data, mapper, _logger, helpers)
        {
            _data = data;
            _context = context;
        }

        public virtual async Task<TeacherObservationDto> GetObservationStudent(int agendaDayStudentId, int academicLoadId, CancellationToken ct = default)
        {
            try
            {
                var entity = await _data.QueryObservationStudent(agendaDayStudentId,academicLoadId,ct);

                _logger.LogInformation("Obteniendo observación de {Entity} para ADS {AdsId}, Load {LoadId}",
                    nameof(TeacherObservation),
                    agendaDayStudentId,
                    academicLoadId);

                return _mapper.Map<TeacherObservationDto?>(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Error al obtener observación de {Entity} para ADS {AdsId}, Load {LoadId}",
                    nameof(TeacherObservation),
                    agendaDayStudentId,
                    academicLoadId);
                throw;
            }
        }

        public async Task<List<TeacherObservationQueryDto>> GetByAgendaDayStudentService(
            int agendaDayStudentId,
            CancellationToken ct = default)
        {
            // 1️⃣ Traer modelos desde Data (ya con Teacher, AgendaDay, AcademicLoad, Subject, etc.)
            var entities = await _data.GetByAgendaDayStudentAsync(agendaDayStudentId, ct);

            // 2️⃣ Mapear con AutoMapper y listo
            var dtos = _mapper.Map<List<TeacherObservationQueryDto>>(entities);

            return dtos;
        }



    }
}
