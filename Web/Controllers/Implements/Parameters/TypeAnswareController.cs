using Business.Interfaces.Commands;
using Business.Interfaces.Querys;
using Entity.Dtos.Parameters.Rh;
using Entity.Dtos.Parameters.Subject;
using Entity.Model.Paramters;
using Web.Controllers.Implements.Abstract;

namespace Web.Controllers.Implements.Parameters
{
    public class TypeAnswareController
       : GenericController<
       TypeAnsware,
       TypeAnswareDto,
       TypeAnswareDto>
    {
        public TypeAnswareController(
            IQueryServices<TypeAnsware, TypeAnswareDto> q,
            ICommandService<TypeAnsware, TypeAnswareDto> c)
          : base(q, c) { }
    }

}
