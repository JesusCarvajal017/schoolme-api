using Data.Interfaces.Group.Querys;
using Entity.Context.Main;
using Entity.Model.Paramters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data.Implements.Querys.Parameters
{
    public class MunicipalityQueryData : BaseGenericQuerysData<Munisipality> , IQuerysMunicipality
    {
        protected readonly ILogger<MunicipalityQueryData> _logger;
        protected readonly AplicationDbContext _context;

        public MunicipalityQueryData(AplicationDbContext context, ILogger<MunicipalityQueryData> logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }

        public override async Task<IEnumerable<Munisipality>> QueryAllAsyn(int? status)
        {
            try
            {
                // El as queryable me permite ir construyendo la consulta
                IQueryable<Munisipality> query = _dbSet.
                                                AsQueryable()
                                                .Include(m => m.Departament);

                if (status.HasValue)
                    query = query.Where(x => x.Status == status.Value);

                var model = await query.ToListAsync();

                _logger.LogInformation("Consulta de la enidad {Entity} se realizo exitosamente", typeof(Munisipality).Name);
                return model;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, "Error en la consulta la entidad {Entity}", typeof(Munisipality).Name);
                throw;
            }
        }


        public virtual async Task<IEnumerable<Munisipality>> QueryMunicpalitysDepartaments(int departementId)
        {
            try
            {
                var query = await _context.Munisipality
                    .AsNoTracking()
                    .Where(e => e.DepartamentId == departementId)
                    .ToListAsync();

                return query;

            }
            catch (Exception ex) {

                _logger.LogError(ex, "Error al consultar municipios para el departamento con Id {DepartementId}", departementId);
                return Enumerable.Empty<Munisipality>();
            }
        }
  



    }
}
