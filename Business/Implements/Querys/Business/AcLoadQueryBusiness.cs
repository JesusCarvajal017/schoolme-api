using AutoMapper;
using Business.Implements.Bases;
using Business.Interfaces.Querys;
using Data.Interfaces.Group.Querys;
using Entity.Dtos.Business.AcademicLoad;
using Entity.Enum;
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

        public async Task<List<TeacherTodayClassDto>> GetTodayLoadsByTeacherAsync(int teacherId, CancellationToken ct = default)
        {
            var todayFlag = MapDayOfWeekToDays(DateTime.Now.DayOfWeek);
            var todayDate = DateOnly.FromDateTime(DateTime.Now);

            var loads = await _data.GetLoadsByTeacherAndDayAsync(teacherId, todayFlag, ct);

            var result = new List<TeacherTodayClassDto>();

            foreach (var a in loads)
            {
                // 👇 AgendaDay de HOY para ese grupo (puede ser null)
                var todayAgenda = a.Group.AgendaDay
                    .FirstOrDefault(ad => ad.Date == todayDate);

                int? agendaDayId = null;
                var agendaState = AgendaDayStateEnum.NotInitialized;

                if (todayAgenda is not null)
                {
                    agendaDayId = todayAgenda.Id;

                    agendaState = todayAgenda.ClosedAt switch
                    {
                        not null => AgendaDayStateEnum.Closed,
                        null => AgendaDayStateEnum.Open,
                    };
                }

                result.Add(new TeacherTodayClassDto
                {
                    AcademicLoadId = a.Id,
                    SubjectName = a.Subject.Name,
                    GroupName = a.Group.Name,
                    GradeName = a.Group.Grade.Name,
                    GroupId = a.GroupId,

                    AgendaDayId = agendaDayId,
                    AgendaState = agendaState,
                });
            }

            return result;
        }

        private Days MapDayOfWeekToDays(DayOfWeek dayOfWeek)
        {
            return dayOfWeek switch
            {
                DayOfWeek.Monday => Days.Monday,
                DayOfWeek.Tuesday => Days.Tuesday,
                DayOfWeek.Wednesday => Days.Wednesday,
                DayOfWeek.Thursday => Days.Thursday,
                DayOfWeek.Friday => Days.Friday,
                DayOfWeek.Saturday => Days.Saturday,
                DayOfWeek.Sunday => Days.Sunday,
                _ => Days.None
            };
        }


    }
}
