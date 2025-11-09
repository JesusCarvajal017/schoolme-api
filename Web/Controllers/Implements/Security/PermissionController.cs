using Business.Interfaces.Commands;
using Business.Interfaces.Querys;
using Entity.Dtos.Security.Permission;
using Entity.Dtos.Security.Person;
using Entity.Model.Security;
using Web.Controllers.Implements.Abstract;

namespace Web.Controllers.Implements.Security
{
    public class PermissionController
       : GenericController<
       Permission,
       PermissionDto,
       PermissionDto>
    {
        public PermissionController(
            IQueryServices<Permission, PermissionDto> q,
            ICommandService<Permission, PermissionDto> c)
          : base(q, c) { }
    }

}
