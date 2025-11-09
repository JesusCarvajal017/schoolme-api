using Data.Interfaces.Group.Querys;
using Entity.Context.Main;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data.Implements.Querys.Security
{
    public class UserRolQueryData : BaseGenericQuerysData<UserRol>, IQuerysUserRol
    {
        protected readonly ILogger<UserRolQueryData> _logger;
        protected readonly AplicationDbContext _context;

        public UserRolQueryData(AplicationDbContext context, ILogger<UserRolQueryData> logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }


        public override async Task<IEnumerable<UserRol>> QueryAllAsyn(int? status)
        {
            try
            {
                IQueryable<UserRol> query = _context.UserRol
                    .AsNoTracking();

                if (status.HasValue)
                    query = query.Where(x => x.Status == status.Value);

                var model = await query
                    .Select(ur => new UserRol
                    {
                        Id = ur.Id,
                        UserId = ur.UserId,
                        RolId = ur.RolId,
                        Status = ur.Status,
                        User = new User
                        {
                            Person = new Person
                            {
                                FisrtName = ur.User.Person.FisrtName,
                                //SecondName = ur.User.Person.SecondName
                            }
                        },
                        Rol = new Rol
                        {
                            Name = ur.Rol.Name
                        }
                    })
                    .OrderBy(x => x.Id)
                    .ToListAsync();

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


        // metodo que consulta que roles tiene el usuario
        public async Task<IEnumerable<UserRol>> QueryUserRol(int IdUser)
        {
            try
            {
                var model = await _context.UserRol
                 .Where(ur => ur.UserId == IdUser)
                 .Select(ur => new UserRol
                 {
                     Id = ur.Id,
                     UserId = ur.UserId,
                     RolId = ur.RolId,
                     Status = ur.Status,  
                     User = new User
                     {
                         Person = new Person
                         {
                             FisrtName = ur.User.Person.FisrtName,
                             //SecondName = ur.User.Person.SecondName
                         }
                     },
                     Rol = new Rol
                     {
                         Name = ur.Rol.Name
                     }
                 })
                 .ToListAsync();

                _logger.LogInformation("Consulta de la enidad {Entity} se realizo exitosamente", typeof(UserRol).Name);
                return model;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, "Error en la consulta la entidad {Entity}", typeof(UserRol).Name);
                throw;
            }
        }

    }
}
