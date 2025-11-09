using Business.Interfaces.Commands;
using Business.Interfaces.Querys;
using Entity.Dtos.Parameters.Group;
using Entity.Model.Paramters;
using Web.Controllers.Implements.Abstract;

namespace Web.Controllers.Implements.Parameters
{
    public class MaterialStatusController
       : GenericController<
       MaterialStatus,
       MaterialStatusDto,
       MaterialStatusDto>
    {
        public MaterialStatusController(
            IQueryServices<MaterialStatus, MaterialStatusDto> q,
            ICommandService<MaterialStatus, MaterialStatusDto> c)
          : base(q, c) { }
    }

}
