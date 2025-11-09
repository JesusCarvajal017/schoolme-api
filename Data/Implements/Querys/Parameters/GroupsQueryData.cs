using Entity.Context.Main;
using Entity.Model.Paramters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data.Implements.Querys.Parameters
{
    public class GroupsQueryData : BaseGenericQuerysData<Groups> 
    {
        protected readonly ILogger<GroupsQueryData> _logger;
        protected readonly AplicationDbContext _context;

        public GroupsQueryData(AplicationDbContext context, ILogger<GroupsQueryData> logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }


        public override async Task<IEnumerable<Groups>> QueryAllAsyn(int? status)
        {
            try
            {
                // El as queryable me permite ir construyendo la consulta
                IQueryable<Groups> query = _dbSet
                    .AsQueryable()
                    .Include(g=> g.Grade);

                if (status.HasValue)
                    query = query.Where(x => x.Status == status.Value);

                var model = await query.ToListAsync();

                _logger.LogInformation("Consulta de la enidad {Entity} se realizo exitosamente", typeof(Groups).Name);
                return model;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, "Error en la consulta la entidad {Entity}", typeof(Groups).Name);
                throw;
            }
        }

        public override async Task<Groups?> QueryById(int id)
        {

            try
            {
                var query = await _dbSet
                  .AsNoTracking()
                  .FirstOrDefaultAsync(e => e.Id == id); ;

                return query;

            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, "Error en la consulta con id {id}", typeof(Groups).Name);
                return null;
            }

        }




    }
}
