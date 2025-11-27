using Data.Interfaces.Group.Querys;
using Entity.Context.Main;
using Entity.Model.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data.Implements.Querys.Business
{
    public class StudentAswareQueryData : BaseGenericQuerysData<StudentAnswer>, IQueryStudentAsware
    {
        protected readonly ILogger<StudentAswareQueryData> _logger;
        protected readonly AplicationDbContext _context;

        public StudentAswareQueryData(AplicationDbContext context, ILogger<StudentAswareQueryData> logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<StudentAnswer>> GetAnswersByAgendaDayStudentAsync(int agendaDayStudentId, CancellationToken ct = default)
        {
            return await _dbSet
                .Where(x => x.AgendaDayStudentId == agendaDayStudentId)
                .Include(x => x.SelectedOptions)
                .ToListAsync(ct);
        }





    }
}
