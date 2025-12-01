using Data.Interfaces.Group.Commands;
using Entity.Context.Main;
using Entity.Dtos.Especific;
using Entity.Dtos.Especific.Security;
using Entity.Dtos.View;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Utilities.helpers;
using Utilities.Helpers.interfaces;

namespace Data.Implements.Commands.Security
{
    public class UserCommandData : BaseGenericCommandsData<User>, ICommandUser
    {
        protected readonly ILogger<UserCommandData> _logger;
        protected readonly AplicationDbContext _context;
        private readonly IEmailSender _emailSender;

        public UserCommandData
            (
                AplicationDbContext context, ILogger<UserCommandData> logger, 
                IEmailSender emailServices
            ) 
            : base(context, logger)
        {
            _context = context;
            _logger = logger;
            _emailSender = emailServices;
        }

        /// <summary>
        ///  Este metodo creara el usuario a partir de solo el email y de ahi, creara el usuario con contraseña automatica
        ///  El formato de la contraseña : SchoolMe.NumeroDocumento 
        /// </summary>
        public override async Task<User> InsertAsync(User entity)
        {
            try
            {
                // Mejora, inyectando servicio de consulta CQRS 
                // consulta de la identificacion para la contraseña
                Person person = await _context.Person
                    .AsNoTracking()
                    .Where(p => p.Id == entity.PersonId)
                    .FirstOrDefaultAsync() ?? throw new Exception($"Persona no encontrada con Id {entity.PersonId}");

                // cracion de formato de contraseña
                string passwordGenerate = $"SchoolMe.{person.Identification}";

                // encriptacion de la contraseña
                entity.Password = HashPassword.EncriptPassword(passwordGenerate);

                await _dbSet.AddAsync(entity);
                await _context.SaveChangesAsync();

                // cuando ya se halla registrado el usuario enviar correo con la contraseña que se genero automaticamente

                UserNewDto dataEmail = new UserNewDto { Email = entity.Email, Password = passwordGenerate , NamePerson= $"{person.FisrtName} {person.LastName}"};

                _ = Task.Run(async () =>
                {

                    try
                    {
                        // pasando parametros para enviar el correo electronico
                        await _emailSender.SendTemplateAsync(
                        toEmail: entity.Email,
                        subject: "Bienvenido a SchoolMe",
                        templateKey: "Helpers.messageEmail.template.Welcome.cshtml",
                        model: dataEmail); 

                    }catch(Exception ex)
                    {

                        // loguear, pero no romper el flujo
                        _logger.LogError(ex, "Error enviando correo de bienvenida a {Email}", entity.Email);

                    }


                });


                return entity;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"registro de usuario denegado:  {entity}");
                throw;
            }
        }

        // <summary>
        //  Metodo sobreescrito, para poder agregarle la encriptacion de contraseña
        // </summary>
        public override async Task<bool> UpdateAsync(User entity)
        {
            try
            {
                entity.UpdatedAt = DateTime.UtcNow;

                // encriptacion de la contraseña
                entity.Password = HashPassword.EncriptPassword(entity.Password);
                _context.Set<User>().Update(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) {
                _logger.LogError(ex, $"Actalizando de usuario denegado:  {entity}");
                throw;
            }
        }

         //<summary>
         // Metodo sobreescrito, para poder agregarle la encriptacion de contraseña
         //</summary>
        public virtual async Task<bool> UpdatePassword(ChangePassword current)
        {
            try
            {
                //busqueda del usuario por nombre
                var user = await _context.Set<User>()
                    .FirstOrDefaultAsync(u => u.Id == current.IdUser);

                if(user == null)
                {
                    return false;
                }

                current.PasswordNew = HashPassword.EncriptPassword(current.PasswordNew);

                user.UpdatedAt = DateTime.UtcNow;
                user.Password = current.PasswordNew;

                await _context.SaveChangesAsync();

                return true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Actalizando de contraseña denegado");
                throw;
            }
        }


        //<summary>
        // Actualizacion de contraseña
        //</summary>
        public virtual async Task<bool> UpdatePhoto(ChangePhoto current)
        {
            try
            {
                //busqueda del usuario por id
                var user = await _context.Set<User>()
                    .FirstOrDefaultAsync(u => u.Id == current.Id);

                if (user == null)
                {
                    return false;
                }

                user.UpdatedAt = DateTime.UtcNow;
                user.Photo = current.Photo;

                await _context.SaveChangesAsync();

                return true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Actalizando de avatar denegado");
                throw;
            }
        }



    }
}
