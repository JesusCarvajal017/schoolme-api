using AutoMapper;
using Business.Implements.Bases;
using Business.Interfaces.Querys;
using Data.Interfaces.Group.Querys;
using Entity.Dtos.Security.UserRol;
using Entity.Model.Security;
using Microsoft.Extensions.Logging;
using Utilities.Helpers.Validations;

namespace Business.Implements.Querys.Security
{
    public class UserRolQueryBusiness : BaseQueryBusiness<UserRol, UserRolDto>, IQueryUserRolServices
    {
        protected readonly IQuerysUserRol _data;

        public UserRolQueryBusiness(
            IQuerysUserRol data,
            IMapper mapper,
            ILogger<UserRolQueryBusiness> _logger,
            IGenericHerlpers helpers) : base(data, mapper, _logger, helpers)
        {
            _data = data;
        }

        public async Task<IEnumerable<UserRolDto>> GetRolsUserServices(int IdUser)
        {
            try
            {
                var entities = await _data.QueryUserRol(IdUser);

                _logger.LogInformation($"Obteniendo los roles del usuario");

                var result = _mapper.Map<IEnumerable<UserRolDto>>(entities);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener al obtener los roles del usuario con el id {IdUser}");
                throw;
            }
        }




    }
}
