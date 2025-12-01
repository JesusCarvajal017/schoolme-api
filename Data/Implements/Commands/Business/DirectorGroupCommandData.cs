using Data.Interfaces.Group.Commands;
using Entity.Context.Main;
using Entity.Model.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Utilities.Exceptions;

namespace Data.Implements.Commands.Business
{
    public class DirectorGroupCommandData : BaseGenericCommandsData<GroupDirector>, ICommandGruopDirector
    {
        protected readonly ILogger<DirectorGroupCommandData> _logger;
        protected readonly AplicationDbContext _context;

        public DirectorGroupCommandData(AplicationDbContext context, ILogger<DirectorGroupCommandData> logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }


        public override async Task<GroupDirector> InsertAsync(GroupDirector entity)
        {
            try
            {
                entity.CreatedAt = DateTime.UtcNow;

                // consulta del docente para obtener el id de person
                var queryPerson = await _context.Teacher
                                    .FirstAsync(g => g.Id == entity.TeacherId);

                // consulta del usuario para poder cambiarle el rol a docente director
                var user = await _context.User
                        .FirstAsync(g => g.Id == queryPerson.PersonId);

                var changeRol = await _context.UserRol
                    .FirstOrDefaultAsync(ur => ur.UserId == user.Id);

                if (changeRol == null)
                    throw new Exception("El usuario no tiene un rol asignado.");

                changeRol.RolId = 5;     // <--- el valor que quieras asignar
                changeRol.UpdatedAt = DateTime.UtcNow;

                await _dbSet.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (DbUpdateException ex)
            {
                throw DbExceptionTranslator.ToBusiness(ex, "insert", typeof(GroupDirector).Name);
            }
        }


        public override async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Set<GroupDirector>().FindAsync(id);

            if (entity == null)
                throw new EntityNotFoundException(typeof(GroupDirector).Name, id);

            try
            {

                var queryPerson = await _context.Teacher
                                   .FirstAsync(g => g.Id == entity.TeacherId);

                // consulta del usuario para poder cambiarle el rol a docente director
                var user = await _context.User
                        .FirstAsync(g => g.Id == queryPerson.PersonId);

                var changeRol = await _context.UserRol
                    .FirstOrDefaultAsync(ur => ur.UserId == user.Id);

                if (changeRol == null)
                    throw new Exception("El usuario no tiene un rol asignado.");

                changeRol.RolId = 3;     // <--- el valor que quieras asignar
                changeRol.UpdatedAt = DateTime.UtcNow;

                _context.Set<GroupDirector>().Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException ex)
            {

                throw DbExceptionTranslator.ToBusiness(ex, "delete", typeof(GroupDirector).Name);

            }
        }






    }
}
