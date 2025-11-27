using Data.Interfaces.Group.Commands;
using Entity.Context.Main;
using Entity.Model.Business;
using Microsoft.Extensions.Logging;

namespace Data.Implements.Commands.Business
{
    public class StudentAnswarCommandData : BaseGenericCommandsData<StudentAnswer>, ICommandStudentAnswar
    {
        protected readonly ILogger<StudentAnswarCommandData> _logger;
        protected readonly AplicationDbContext _context;

        public StudentAnswarCommandData(AplicationDbContext context, ILogger<StudentAnswarCommandData> logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task RegisterAnswersAsync(IEnumerable<StudentAnswer> answers, CancellationToken ct = default)
        {
            _dbSet.AddRange(answers);
            await _context.SaveChangesAsync(ct);
        }

        public async Task SaveChangesAsync(CancellationToken ct = default)
        {
            await _context.SaveChangesAsync(ct);
        }


    }
}
