using Business.Interfaces.Commands;
using Business.Interfaces.Querys;
using Entity.Dtos.Security.Module;
using Entity.Model.Security;
using Web.Controllers.Implements.Abstract;

namespace Web.Controllers.Implements.Security
{
    public class ModuleController
       : GenericController<
       Module,
       ModuleDto,
       ModuleDto>
    {
        public ModuleController(
            IQueryServices<Module, ModuleDto> q,
            ICommandService<Module, ModuleDto> c)
          : base(q, c) { }
    }

}
