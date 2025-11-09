using Data.Implements.Querys;
using Entity.Context.Main;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Data.Implements.Querys.Security
{
    public class RolFormPermissionQueryData : BaseGenericQuerysData<RolFormPermission> 
    {

        protected readonly ILogger<RolFormPermissionQueryData> _logger;
        protected readonly AplicationDbContext _context;

        public RolFormPermissionQueryData(AplicationDbContext context, ILogger<RolFormPermissionQueryData> logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }

        public override async Task<IEnumerable<RolFormPermission>> QueryAllAsyn(int? status)
        {
            try
            {
                IQueryable<RolFormPermission> query = _context.RolFormPermission.AsNoTracking()
                    .Include(ur => ur.Rol)
                    .Include(ur => ur.Form)
                    .Include(ur => ur.Permission);

                if (status.HasValue)
                    query = query.Where(x => x.Status == status.Value);


                var model = await query.OrderBy(x => x.Id).ToListAsync();

                _logger.LogInformation("Consulta de la enidad {Entity} se realizo exitosamente", typeof(RolFormPermission).Name);
                return model;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, "Error en la consulta la entidad {Entity}", typeof(RolFormPermission).Name);
                throw;
            }
        }

    }
}
