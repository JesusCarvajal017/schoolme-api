using Entity.Context.Main;
using Entity.Dtos.Especific;
using Entity.Dtos.Services;
using Entity.Dtos.View;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data.Implements.View
{
    // !! Importante
    // cometario para mejorar mas adelante: la mitad debe ir en business, para el la creacion de dto de menu
    public class ViewData
    {
        protected readonly AplicationDbContext _context;
        protected readonly ILogger<ViewData> _logger;

        public ViewData(AplicationDbContext db, ILogger<ViewData> logger)
        {
            _context = db;
            _logger = logger;
        }

        // <summary>
        //  Este metodo nos va a proporcional el menu
        // </summary>
        public async Task<List<MenuDto>> BuildMenuAsync(int roleId, CancellationToken ct = default)
        {
            // Si un form puede tener varios permisos para el mismo rol,
            // define una prioridad para quedarte con uno:
            var permRank = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                ["admin"] = 3,
                ["editor"] = 2,
                ["viewer"] = 1
            };

            var flat = await (
                from rfp in _context.RolFormPermission.AsNoTracking()
                join f in _context.Form.AsNoTracking() on rfp.FormId equals f.Id
                join p in _context.Permission.AsNoTracking() on rfp.PermissionId equals p.Id
                join mf in _context.ModuleForm.AsNoTracking() on f.Id equals mf.FormId
                join m in _context.Module.AsNoTracking() on mf.ModuleId equals m.Id
                where rfp.RolId == roleId
                select new
                {
                    ModuleId = m.Id,
                    ModuleName = m.Name,
                    ModuleIcon = m.Icon,
                    ModulePath = m.Path,
                    ModuleOrd = m.Order,

                    FormId = f.Id,
                    FormName = f.Name,
                    FormOrd = f.Order,
                    FormPath = f.Path,

                    Permission = p.Name
                }
            ).ToListAsync(ct);

            // Si el mismo form trae varios permisos para el mismo rol, nos quedamos con el de mayor prioridad
            var bestPerForm = flat
                .GroupBy(x => new { x.ModuleId, x.ModuleName, x.ModuleIcon, x.ModulePath, x.ModuleOrd, x.FormId, x.FormName, x.FormOrd })
                .Select(g =>
                {
                    var best = g
                        .OrderByDescending(x => permRank.TryGetValue(x.Permission, out var r) ? r : 0)
                        .First();

                    return new
                    {
                        best.ModuleId,
                        best.ModuleName,
                        best.ModuleIcon,
                        best.ModulePath,
                        best.ModuleOrd,

                        best.FormId,
                        best.FormName,
                        best.FormOrd,
                        best.FormPath,

                        best.Permission
                    };
                });

            // Agrupamos por módulo y proyectamos el menú final
            var menu = bestPerForm
                .GroupBy(x => new { x.ModuleId, x.ModuleName, x.ModuleIcon, x.ModulePath, x.ModuleOrd })
                .Select(g => new MenuDto
                {
                    Name = g.Key.ModuleName,
                    Icon = g.Key.ModuleIcon,
                    Path = g.Key.ModulePath,
                    Order = g.Key.ModuleOrd,
                    Formularios = g
                        .OrderBy(x => x.FormOrd)
                        .Select(x => new FormItemDto
                        {
                            Name = x.FormName,
                            Permission = x.Permission,
                            Orden = x.FormOrd,
                            Path = x.FormPath
                        })
                        .ToList()
                })
                .OrderBy(m => m.Order)
                .ThenBy(m => m.Name)
                .ToList();

            // el modulo de incio por defecto para todos si importar el rol
             menu.Insert(0, new MenuDto { Name = "inicio", Icon = "home", Path = "/dashboard", Order = 1, Formularios = new() });

            return menu;
        }

        public async Task<CountRegistersDto> QueryCountRegister() 
        {
            int  queryPerson = await _context.Person.AsNoTracking().CountAsync(); 
            int queryStudents = await _context.Students.AsNoTracking().CountAsync();
            int queryTeacher = await _context.Teacher.AsNoTracking().CountAsync();
            int queryAttedanst = await _context.Attendants.AsNoTracking().CountAsync();

            return new CountRegistersDto
            {
                Persons = queryPerson,
                Students = queryStudents,
                Attendats = queryAttedanst,
                Teachers = queryTeacher
            };
        }


        private const int STATUS_ACTIVO = 1;
        private const int STATUS_CONFIRMADO = 3;

        // 1) PIE: Docentes / Estudiantes / Acudientes
        public async Task<PieUsuariosDto> GetPieUsuariosAsync()
        {
            var docentes = await _context.Teacher
                .CountAsync(t => t.Status == STATUS_ACTIVO);

            var estudiantes = await _context.Students
                .CountAsync(s => s.Status == STATUS_ACTIVO);

            // Aquí puedes decidir si contar relaciones o personas únicas.
            // Ejemplo: número de personas distintas que son acudientes:
            var acudientes = await _context.Attendants
                .Where(a => a.Status == STATUS_ACTIVO)
                .Select(a => a.PersonId)
                .Distinct()
                .CountAsync();

            return new PieUsuariosDto
            {
                Docentes = docentes,
                Estudiantes = estudiantes,
                Acudientes = acudientes
            };
        }

        // 2) BARRAS: Agendas creadas vs confirmadas por mes (últimos N meses)
        public async Task<List<MesAgendasDto>> GetAgendasMensualesAsync(int meses = 7)
        {
            // 1) Trabajamos todo con DateOnly, no con DateTime
            var hoyDateTime = DateTime.UtcNow;                          
            var hoy = DateOnly.FromDateTime(hoyDateTime);               

            // Primer día del mes actual, menos (meses - 1)
            var inicioMes = new DateOnly(hoy.Year, hoy.Month, 1)
                .AddMonths(-(meses - 1));

            // 2.1. Agendas creadas por mes (AgendaDay.Date es DateOnly)
            var agendasCreadas = await _context.AgendaDay
                .Where(ad =>
                    ad.Status == STATUS_ACTIVO &&
                    ad.Date >= inicioMes &&
                    ad.Date <= hoy)
                .GroupBy(ad => new { ad.Date.Year, ad.Date.Month })
                .Select(g => new
                {
                    g.Key.Year,
                    g.Key.Month,
                    Count = g.Count()
                })
                .ToListAsync();

            // 2.2. Agendas confirmadas por mes (a nivel de estudiante)
            var agendasConfirmadas = await _context.AgendaDayStudent
                .Where(ads =>
                    ads.Status == STATUS_ACTIVO &&
                    ads.AgendaDay != null &&
                    ads.AgendaDay.Status == STATUS_ACTIVO &&
                    ads.AgendaDay.Date >= inicioMes &&
                    ads.AgendaDay.Date <= hoy &&
                    ads.AgendaDayStudentStatus == STATUS_CONFIRMADO)
                .GroupBy(ads => new { ads.AgendaDay!.Date.Year, ads.AgendaDay.Date.Month })
                .Select(g => new
                {
                    g.Key.Year,
                    g.Key.Month,
                    Count = g.Count()
                })
                .ToListAsync();

            // 2.3. Armar lista por cada mes del rango (aunque no haya datos)
            var resultado = new List<MesAgendasDto>();

            for (int i = 0; i < meses; i++)
            {
                var fechaMes = inicioMes.AddMonths(i); 
                var y = fechaMes.Year;
                var m = fechaMes.Month;

                var creadas = agendasCreadas
                    .FirstOrDefault(x => x.Year == y && x.Month == m)?.Count ?? 0;

                var confirmadas = agendasConfirmadas
                    .FirstOrDefault(x => x.Year == y && x.Month == m)?.Count ?? 0;

                resultado.Add(new MesAgendasDto
                {
                    Label = new DateTime(y, m, 1)
                        .ToString("MMM", new System.Globalization.CultureInfo("es-ES")),
                    AgendasCreadas = creadas,
                    AgendasConfirmadas = confirmadas
                });
            }

            return resultado;
        }


        // 3) LÍNEA: Confirmaciones por semana (últimas N semanas)
        public async Task<List<SemanaConfirmacionesDto>> GetConfirmacionesSemanalesAsync(int semanas = 6)
        {
            var hoy = DateTime.UtcNow.Date;

            // Encontrar el lunes de la semana actual
            int delta = DayOfWeek.Monday - hoy.DayOfWeek;
            if (delta > 0) delta -= 7; // Ajuste si hoy es domingo, etc.
            var lunesEstaSemana = hoy.AddDays(delta);

            // Lunes de la primera semana que queremos
            var lunesInicio = lunesEstaSemana.AddDays(-7 * (semanas - 1));

            // Traer confirmaciones desde lunesInicio
            var confirmados = await _context.AgendaDayStudent
                .Where(ads =>
                    ads.Status == STATUS_ACTIVO &&
                    ads.AgendaDayStudentStatus == STATUS_CONFIRMADO &&
                    ads.CompletedAt != null &&
                    ads.CompletedAt.Value.Date >= lunesInicio &&
                    ads.CompletedAt.Value.Date <= hoy)
                .Select(ads => ads.CompletedAt!.Value.Date)
                .ToListAsync();

            // Agrupar en memoria por semana relativa
            var resultado = new List<SemanaConfirmacionesDto>();

            for (int i = 0; i < semanas; i++)
            {
                var inicioSemana = lunesInicio.AddDays(7 * i);
                var finSemana = inicioSemana.AddDays(6);

                var count = confirmados
                    .Count(d => d >= inicioSemana && d <= finSemana);

                var label = $"S{i + 1}"; // o $"Semana {ISOWeek.GetWeekOfYear(inicioSemana)}"

                resultado.Add(new SemanaConfirmacionesDto
                {
                    Label = label,
                    Confirmaciones = count
                });
            }

            return resultado;
        }

        // 4) Método “todo en uno” para el dashboard
        public async Task<DashboardDto> GetDashboardAsync()
        {
            var pie = await GetPieUsuariosAsync();
            var barras = await GetAgendasMensualesAsync();
            var linea = await GetConfirmacionesSemanalesAsync();

            return new DashboardDto
            {
                PieUsuarios = pie,
                AgendasMensuales = barras,
                ConfirmacionesSemanales = linea
            };
        }







    }
}
