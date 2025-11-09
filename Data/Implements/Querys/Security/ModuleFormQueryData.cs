using Data.Implements.Querys;
using Entity.Context.Main;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Org.BouncyCastle.Tls;

namespace Data.Implements.Querys.Security
{
    public class ModuleFormQueryData : BaseGenericQuerysData<ModuleForm> 
    {

        protected readonly ILogger<ModuleFormQueryData> _logger;
        protected readonly AplicationDbContext _context;

        public ModuleFormQueryData(AplicationDbContext context, ILogger<ModuleFormQueryData> logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }

        public override async Task<IEnumerable<ModuleForm>> QueryAllAsyn(int? status)
        {
            try
            {
                IQueryable<ModuleForm> query = _dbSet
                    .Include(ur => ur.Form)
                    .Include(ur => ur.Module);

                // Filtro opcional de si traer por status
                if (status.HasValue)
                    query = query.Where(x => x.Status == status.Value);
                   
                var model = await query.OrderBy(x => x.Id).ToListAsync();
                      

                _logger.LogInformation("Consulta de la enidad {Entity} se realizo exitosamente", typeof(ModuleForm).Name);
                return model;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, "Error en la consulta la entidad {Entity}", typeof(ModuleForm).Name);
                throw;
            }
        }

    }
}
