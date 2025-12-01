using Data.Interfaces.Group.Commands;
using Entity.Context.Main;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Utilities.Exceptions;

namespace Data.Implements.Commands.Security
{
    public class PersonCommandData : BaseGenericCommandsData<Person>, ICommanPerson
    {
        protected readonly ILogger<PersonCommandData> _logger;
        protected readonly AplicationDbContext _context;

        public PersonCommandData(AplicationDbContext context, ILogger<PersonCommandData> logger
            
            ) : base(context, logger)
        {
            _context = context;
            _logger = logger;
           
        }

        public virtual async Task<Person> InsertComplete(Person entity)
        {
        
            using var tx = await _context.Database.BeginTransactionAsync();

            try
            {
                entity.CreatedAt = DateTime.UtcNow;

                // si viene DataBasic, NO asignes PersonId; deja que EF lo ponga
                if (entity.DataBasic != null)
                {
                    entity.DataBasic.Person = entity; // fix-up explícito
                }



                await _dbSet.AddAsync(entity);        // agrega el grafo: Person (+ DataBasic)
                await _context.SaveChangesAsync();    // EF: inserta Person, luego DataBasic con PersonId

                await tx.CommitAsync();

                // data de la persona creada
                var person = await _dbSet.AsNoTracking()
                    .Include(p => p.DataBasic)
                    .FirstAsync(p => p.Id == entity.Id);

                // opcional: devolver con navegación cargada
                return person;
            }
            catch (DbUpdateException ex)
            {
                await tx.RollbackAsync();
                throw DbExceptionTranslator.ToBusiness(ex, "insert", nameof(Person));
            }
        }

        public virtual async Task<Person> UpdateCompleteAsync(Person trackedEntity)
        {
            using var tx = await _context.Database.BeginTransactionAsync();
            try
            {
                // trackedEntity ya está adjunta al contexto y con cambios mapeados
                await _context.SaveChangesAsync();

                // devolver refrescado y sin tracking
                var result = await _dbSet.AsNoTracking()
                    .Include(p => p.DataBasic)
                    .FirstAsync(p => p.Id == trackedEntity.Id);

                await tx.CommitAsync();
                return result;
            }
            catch (DbUpdateException ex)
            {
                await tx.RollbackAsync();
                throw DbExceptionTranslator.ToBusiness(ex, "update", nameof(Person));
            }
        }

        public virtual async Task<Person?> QueryByIdTrackedAsync(int id)
        {
            return await _dbSet
                .Include(p => p.DataBasic)
                .FirstOrDefaultAsync(p => p.Id == id); // SIN AsNoTracking => tracked
        }


        public override async Task<bool> DeleteAsync(int id)
        {
            using var tx = await _context.Database.BeginTransactionAsync();

            try
            {
                // 1) Cargar todo el grafo necesario
                var person = await _context.Person
                    .Include(p => p.DataBasic)
                    .Include(p => p.User)
                        .ThenInclude(u => u.UserRol)
                    .FirstOrDefaultAsync(p => p.Id == id);

                if (person is null)
                    throw new Exception($"Persona {id} no encontrada");

                // 2) Borrar enlaces UserRol (tabla puente)
                if (person.User?.UserRol != null && person.User.UserRol.Any())
                    _context.RemoveRange(person.User.UserRol);

                // 3) Borrar User (si no confías en cascada)
                if (person.User != null)
                    _context.User.Remove(person.User);

                // 4) Borrar DataBasic (si no confías en cascada)
                if (person.DataBasic != null)
                    _context.DataBasic.Remove(person.DataBasic);

                // 5) Borrar Person (principal)
                _context.Person.Remove(person);

                await _context.SaveChangesAsync();
                await tx.CommitAsync();

                return true; // ✅ Todo salió bien
            }
            catch (Exception ex)
            {
                await tx.RollbackAsync();

                // puedes loguearlo si tienes un ILogger inyectado
                // _logger.LogError(ex, "Error al eliminar persona {Id}", id);

                // Opcional: propagar la excepción o devolver false
                // throw; // si quieres que se propague al middleware
                return false;
            }
        }



    }
}
