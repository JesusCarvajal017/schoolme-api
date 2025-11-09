using Business.Interfaces.Commands;
using Business.Interfaces.Querys;
using Entity.Dtos.Security.RolFormPermission;
using Entity.Model.Security;
using Web.Controllers.Implements.Abstract;

namespace Web.Controllers.Implements.Security
{
    public class RolFormPermissionController
       : GenericController<
       RolFormPermission,
       RolFormPermissionDto,
       RolFormPermissionCreateDto>
    {
        public RolFormPermissionController(
            IQueryServices<RolFormPermission, RolFormPermissionDto> q,
            ICommandService<RolFormPermission, RolFormPermissionCreateDto> c)
          : base(q, c) { }
    }

}
