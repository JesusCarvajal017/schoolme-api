using Entity.Context.Main;
using Entity.Dtos.Especific;
using Entity.Dtos.Services;
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

    }
}
