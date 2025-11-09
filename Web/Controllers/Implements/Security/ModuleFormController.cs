using Business.Interfaces.Commands;
using Business.Interfaces.Querys;
using Entity.Dtos.Security.ModuleForm;
using Entity.Model.Security;
using Web.Controllers.Implements.Abstract;

namespace Web.Controllers.Implements.Security
{
    public class ModuleFormController
       : GenericController<
       ModuleForm,
       ModuleFormDto,
       ModuleFormCreation>
    {
        public ModuleFormController(
            IQueryServices<ModuleForm, ModuleFormDto> q,
            ICommandService<ModuleForm, ModuleFormCreation> c)
          : base(q, c) { }
    }

}
