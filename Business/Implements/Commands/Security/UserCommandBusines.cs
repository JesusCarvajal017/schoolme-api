using AutoMapper;
using Business.Implements.Bases;
using Business.Interfaces.Querys;
using Data.Interfaces.Group.Commands;
using Data.Interfaces.Group.Querys;
using Entity.Context.Main;
using Entity.Dtos.Especific;
using Entity.Dtos.Especific.Security;
using Entity.Dtos.Security.User;
using Entity.Model.Security;
using Microsoft.Extensions.Logging;
using Utilities.AlmacenadorArchivos.Interface;
using Utilities.Helpers.Validations;

namespace Business.Implements.Commands.Security
{
    public class UserCommandBusines : BaseCommandsBusiness<User, UserDto>, ICommandUserServices
    {
        protected readonly ICommandUser _data;
        protected readonly IQuerys<User> _dataQuery;
        protected readonly IAlmacenadorArchivos _svArchv;
        private readonly string contenedor = "usuarios";
       

        public UserCommandBusines(
            ICommandUser data,
            IMapper mapper,
            ILogger<UserCommandBusines> _logger,
            IAlmacenadorArchivos alamacenadorArchivos,
            IGenericHerlpers helpers,
            IQuerys<User> dataQuery,
            AplicationDbContext context
            ) : base(data, mapper, _logger, helpers, context)
        {
            _data = data;
            _svArchv = alamacenadorArchivos;
            _dataQuery = dataQuery;
        }

        /// <summary>
        /// Valida un DTO utilizando las reglas de validación de FluentValidation
        /// </remarks>
        protected async Task EnsureValid(UserDto dto)
        {
            var validationResult = await _helpers.Validate(dto);
            if (!validationResult.IsValid)
            {
                var errors = string.Join(", ", validationResult.Errors);
                throw new ArgumentException($"Validación fallida: {errors}");
            }
        }

        /// <summary>
        /// Valida un DTO utilizando las reglas de validación de FluentValidation
        /// </remarks>
        protected async Task EnsureValid(UserCreateDto dto)
        {
            var validationResult = await _helpers.Validate(dto);
            if (!validationResult.IsValid)
            {
                var errors = string.Join(", ", validationResult.Errors);
                throw new ArgumentException($"Validación fallida: {errors}");
            }
        }

        // <summary>
        // Metodo que crea un usuario generando una contraseña aleatoria y enviando un correo electronico para inviar la contraseña
        // al usuario
        // </summary>
        public virtual async Task<UserDto> CreateRemastered(UserCreateDto dto)
        {
            try
            {
                // validacion de dto
                await EnsureValid(dto);

                var entity = _mapper.Map<User>(dto);

                if(dto.Photo is not null)
                {
                    //Url de la nube o otro servicio
                    var url = await _svArchv.Almacenar(contenedor, dto.Photo);
                    entity.Photo = url;
                }
                else
                {
                    entity.Photo = "defaul.png";
                }


                 entity = await _data.InsertAsync(entity);
                _logger.LogInformation($"Creando nuevo {typeof(User).Name}");
                return _mapper.Map<UserDto>(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear {typeof(User).Name} desde DTO: {ex.Message}");
                throw;
            }
        }

        public virtual async Task<bool> ChangePasswordServices(ChangePassword dto)
        {
            try
            {
                if(dto.PasswordNew == dto.PasswordConfirm)
                {
                    return await _data.UpdatePassword(dto);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar la contraseña de la persona {dto.IdUser}");
                throw;
            }
        }

        // actualización con implementacion de guardar imagen
        public override async Task<bool> UpdateServices(UserDto dto)
        {
            try
            {
                await EnsureValid(dto);

                // existencia del usuario para la posterios actualización
                // tener cuidado con este parche, puede que se vaya el 0, esto para el int? != int
                var user =  await _dataQuery.QueryById(dto.Id ?? 0);

                var entity = _mapper.Map<User>(dto);

                if (dto.Photo is not null)
                {
                    await _svArchv.Borrar(user.Photo, contenedor);

                    // eliminacion de destino == azure o local
                    var url = await _svArchv.Almacenar(contenedor, dto.Photo);
                    entity.Photo = url;
                }
                
                return await _data.UpdateAsync(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar {typeof(UserDto).Name} desde DTO: {ex.Message}");
                throw;
            }
        }

        // Actualización avatars
        public virtual async Task<bool> ChangePhotoServices(ChangePhotoDto dto)
        {
            try
            {
                // existencia del usuario para la posterios actualización
                // tener cuidado con este parche, puede que se vaya el 0, esto para el int? != int
                var user = await _dataQuery.QueryById(dto.Id);

                var entity = _mapper.Map<ChangePhoto>(dto);

                if (dto.Photo is not null)
                {
                    await _svArchv.Borrar(user.Photo, contenedor);

                    // eliminacion de destino == azure o local
                    var url = await _svArchv.Almacenar(contenedor, dto.Photo);
                    entity.Photo = url;
                }

                return await _data.UpdatePhoto(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar {typeof(UserDto).Name} desde DTO: {ex.Message}");
                throw;
            }
        }

        public override async Task<bool> DeleteServices(int id)
        {
            try
            {
                _logger.LogInformation($"Eliminando {typeof(User).Name} con ID: {id}");
                var user = await _dataQuery.QueryById(id);

                await _svArchv.Borrar(user.Photo, contenedor);

                return await _data.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar {typeof(User).Name} con ID {id}: {ex.Message}");
                throw;
            }
        }





    }
}
