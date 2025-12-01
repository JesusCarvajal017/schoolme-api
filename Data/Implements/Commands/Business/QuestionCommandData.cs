using Data.Interfaces.Group.Commands;
using Entity.Context.Main;
using Entity.Dtos.Business.Student;
using Entity.Model.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Utilities.Exceptions;

namespace Data.Implements.Commands.Business
{
    public class QuestionCommandData : BaseGenericCommandsData<Question>, ICommandQuestion
    {
        protected readonly ILogger<QuestionCommandData> _logger;
        protected readonly AplicationDbContext _context;

        public QuestionCommandData(AplicationDbContext context, ILogger<QuestionCommandData> logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }

        public override async Task<Question> InsertAsync(Question entity)
        {
            try
            {
                entity.CreatedAt = DateTime.UtcNow;

                await _dbSet.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (DbUpdateException ex)
            {
                throw DbExceptionTranslator.ToBusiness(ex, "insert", typeof(Question).Name);
            }
        }

        public virtual async Task<Question> InsertWithOptionsAsync(Question entity, IEnumerable<QuestionOption> options)
        {
            try
            {
                using var tx = await _context.Database.BeginTransactionAsync();

                entity.CreatedAt = DateTime.UtcNow;

                await _dbSet.AddAsync(entity);
                await _context.SaveChangesAsync(); // aquí ya tiene Id

                // Setear el QuestionId en cada opción y fechas
                foreach (var opt in options)
                {
                    opt.QuestionId = entity.Id;
                    opt.CreatedAt = DateTime.UtcNow;
                }

                await _context.Set<QuestionOption>().AddRangeAsync(options);
                await _context.SaveChangesAsync();

                await tx.CommitAsync();

                return entity;
            }
            catch (DbUpdateException ex)
            {
                throw DbExceptionTranslator.ToBusiness(ex, "insert", nameof(Question));
            }
        }







    }
}
