using Business.Interfaces.Commands;
using Business.Interfaces.Querys;
using Entity.Dtos.Security.Rol;
using Entity.Model.Security;
using Web.Controllers.Implements.Abstract;

namespace Web.Controllers.Implements.Security
{
    public class RolController
       : GenericController<
       Rol,
       RolDto,
       RolDto>
    {
        public RolController(
            IQueryServices<Rol, RolDto> q,
            ICommandService<Rol, RolDto> c)
          : base(q, c) { }

    }

}
