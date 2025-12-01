using Business.Interfaces.Commands;
using Business.Interfaces.Querys;
using Entity.Dtos.Security.Form;
using Entity.Model.Security;
using Web.Controllers.Implements.Abstract;

namespace Web.Controllers.Implements.Security
{
    public class FormController
       : GenericController<
       Form,
       FormDto,
       FormDto>
    {
        public FormController(
            IQueryServices<Form, FormDto> q,
            ICommandService<Form, FormDto> c)
          : base(q, c) { }
    }

}
