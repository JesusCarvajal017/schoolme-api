using Data.Interfaces.Group.Querys;
using Entity.Context.Main;
using Entity.Model.Business;
using Entity.Model.Paramters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data.Implements.Querys.Business
{
    public class GroupDirectorQueryData : BaseGenericQuerysData<GroupDirector> , IQuerysGroupDirector
    {
        protected readonly ILogger<GroupDirectorQueryData> _logger;
        protected readonly AplicationDbContext _context;

        public GroupDirectorQueryData(AplicationDbContext context, ILogger<GroupDirectorQueryData> logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }

        public override async Task<IEnumerable<GroupDirector>> QueryAllAsyn(int? status)
        {
            try
            {
                // El as queryable me permite ir construyendo la consulta
                IQueryable<GroupDirector> query = _dbSet.
                                                AsQueryable()
                                                .Include(p => p.Teacher)
                                                    .ThenInclude(d => d.Person)
                                                .Include(p => p.Groups);


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


        // consulta de grupos los cuales el docente director esta a cargo
        public virtual async Task<IEnumerable<GroupDirector>> GroupsDirector(int teacherId)
        {
            try
            {
                var query = await _dbSet
                   .AsNoTracking()
                    .Where(t => t.TeacherId == teacherId)
                    .Include(t => t.Groups)
                        .ThenInclude(g => g.Grade)
                    .Include(t => t.Groups)
                        .ThenInclude(g => g.Agenda)
                    .Include(t => t.Groups)
                        .ThenInclude(g => g.AgendaDay)
                    .ToListAsync();

                return query;

            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, "Error en la consulta con id {id}", typeof(GroupDirector).Name);
                return null;
            }
        }

    }
}
