using Data.Interfaces.Group.Querys;
using Entity.Context.Main;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data.Implements.Querys.Security
{
    public class PersonQueryData : BaseGenericQuerysData<Person>, IQuerysPerson
    {
        protected readonly ILogger<PersonQueryData> _logger;
        protected readonly AplicationDbContext _context;

        public PersonQueryData(AplicationDbContext context, ILogger<PersonQueryData> logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }

        public override async Task<IEnumerable<Person>> QueryAllAsyn(int? status)
        {
            try
            {
                IQueryable<Person> query = _context.Person.AsNoTracking()
                     .Include(ur => ur.DocumentType);

                if (status.HasValue)
                    query = query.Where(x => x.Status == status.Value);

                var model = await query.OrderBy(x => x.Id).ToListAsync();

                //ToListAsync();
                _logger.LogInformation("Consulta de la enidad {Entity} se realizo exitosamente", typeof(UserRol).Name);
                return model;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, "Error en la consulta la entidad {Entity}", typeof(UserRol).Name);
                throw;
            }
        }

        public virtual async Task<Person> QueryCompleteData(int personId)
        {
            try
            {
                var query = await _dbSet
                 .AsNoTracking()
                 .Include(p => p.DocumentType)
                 .Include(p => p.Attendants)
                 .Include(p => p.DataBasic)
                     .ThenInclude(d => d.Rh)
                 .Include(p => p.DataBasic)
                     .ThenInclude(d => d.Eps)
                 .Include(p => p.DataBasic)
                     .ThenInclude(d => d.Munisipality)
                        .ThenInclude(m=> m.Departament)
                 .Include(p => p.DataBasic)
                     .ThenInclude(d => d.MaterialStatus)
                 .AsSplitQuery() // recomendable cuando hay varias colecciones
                 .FirstOrDefaultAsync(p => p.Id == personId);

                return query;

            }
            catch (Exception ex)
            {

                _logger.LogInformation(ex, "Error en la consulta la entidad {Entity}", typeof(UserRol).Name);
                return new Person();
            }
        }
        public override async Task<Person?> QueryById(int id)
        {
            try
            {
                var query = await _dbSet
                  .AsNoTracking()
                  .Include(p => p.DocumentType)
                 .Include(p => p.Attendants)
                 .Include(p => p.DataBasic)
                     .ThenInclude(d => d.Rh)
                 .Include(p => p.DataBasic)
                     .ThenInclude(d => d.Eps)
                 .Include(p => p.DataBasic)
                     .ThenInclude(d => d.Munisipality)
                        .ThenInclude(m => m.Departament)
                 .Include(p => p.DataBasic)
                     .ThenInclude(d => d.MaterialStatus)
                 .AsSplitQuery() // recomendable cuando hay varias colecciones
                  .FirstOrDefaultAsync(e => e.Id == id); ;

                return query;

            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, "Error en la consulta con id {id}", typeof(Person).Name);
                return null;
            }

        }

       




    }
}