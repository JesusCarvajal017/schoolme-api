using AutoMapper;
using Business.Implements.Bases;
using Business.Interfaces.Querys;
using Data.Interfaces.Group.Commands;
using Entity.Dtos.Security.Person;
using Entity.Dtos.Security.User;
using Entity.Model.Business;
using Entity.Model.Security;
using Microsoft.Extensions.Logging;
using Utilities.Exceptions;
using Utilities.Helpers.Validations;

namespace Business.Implements.Commands.Security
{
    public class PersonCommandBusines : BaseCommandsBusiness<Person, PersonDto>, ICommandPersonServices
    {
        protected readonly ICommanPerson _data;

        // para poder crear el usuario y darle la asignación de rol
        protected readonly ICommandUser _commandUser;
        protected readonly ICommands<UserRol> _commandUserRol;

        public PersonCommandBusines(
            ICommanPerson data,
            IMapper mapper,
            ILogger<PersonCommandBusines> _logger,
            IGenericHerlpers helpers, ICommandUser commandUser, 
            ICommands<UserRol> commandUserRol
            ) : base(data, mapper, _logger, helpers)
        {
            _data = data;
            _commandUser = commandUser;
            _commandUserRol = commandUserRol;

        }

        /// <summary>
        /// Valida un DTO utilizando las reglas de validación de FluentValidation
        /// </remarks>
        protected async Task EnsureValid(PersonDto dto)
        {
            var validationResult = await _helpers.Validate(dto);
            if (!validationResult.IsValid)
            {
                var errors = string.Join(", ", validationResult.Errors);
                throw new ArgumentException($"Validación fallida: {errors}");
            }
        }

        protected async Task EnsureValid(PersonCompleteDto dto)
        {
            var validationResult = await _helpers.Validate(dto);
            if (!validationResult.IsValid)
            {
                var errors = string.Join(", ", validationResult.Errors);
                throw new ArgumentException($"Validación fallida: {errors}");
            }
        }


        // Creación de persona con sus datos basicos
        // Creación del usuario
        // Asignacion del rol
        public virtual async Task<PersonCompleteDto> CreateRemastered(PersonCompleteDto current, int? rolId)
        {
            try
            {
                // validacion de dto
                await EnsureValid(current);

                // modelo mapeado, listo para la ejecución
                var entity = _mapper.Map<Person>(current);

                // retorna person
                entity = await _data.InsertComplete(entity);

                if(rolId != null)
                {
                    User user = new User { PersonId = entity.Id, Email = current.Email, Photo = "defaul.png" };

                    // creacion del usuario
                    var userCreate = await _commandUser.InsertAsync(user);

                    UserRol userRol = new UserRol { UserId = userCreate.Id, RolId = rolId ?? 0 };

                    // asigancion de rol
                    var rolUser = await _commandUserRol.InsertAsync(userRol);
                }

                _logger.LogInformation($"Creando nuevo {typeof(Person).Name}");
                return _mapper.Map<PersonCompleteDto>(entity);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public virtual async Task<PersonCompleteDto> UpdateRemasteredAsync(int id, PersonCompleteDto dto)
        {
            await EnsureValid(dto); // usa tu RuleSet de update

            var existing = await _data.QueryByIdTrackedAsync(id);
            if (existing is null)
                throw new NotFoundException($"No existe {nameof(Person)} con id {id}");

            // Mapear ENCIMA de la entidad cargada (tracked).
            // Gracias al Profile, los nulls no pisan valores.
            _mapper.Map(dto, existing);

            // Si viene DataBasic en el DTO y el existente no tenía, crear placeholder
            if (dto.DataBasic != null && existing.DataBasic == null)
            {
                existing.DataBasic = new DataBasic
                {
                    Person = existing   // EF fijará PersonId
                };

                // Vuelve a mapear solo DataBasic para aplicar campos no nulos
                _mapper.Map(dto.DataBasic, existing.DataBasic);
            }

            existing.UpdatedAt = DateTime.UtcNow;

            var updated = await _data.UpdateCompleteAsync(existing); // guarda en Data
            return _mapper.Map<PersonCompleteDto>(updated);
        }

        public override async Task<bool> DeleteServices(int id)
        {
            try
            {
                _logger.LogInformation($"Eliminando {typeof(Person).Name} con ID: {id}");
                return await _data.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                //_logger.LogError($"Error al eliminar {typeof(T).Name} con ID {id}: {ex.Message}");
                throw;
            }
        }



    }
}
