using Business.Interfaces.Commands;
using Business.Interfaces.Querys;
using Entity.Dtos.Parameters.Rh;
using Entity.Model.Paramters;
using Web.Controllers.Implements.Abstract;

namespace Web.Controllers.Implements.Parameters
{
    public class RhController
       : GenericController<
       Rh,
       RhDto,
       RhDto>
    {
        public RhController(
            IQueryServices<Rh, RhDto> q,
            ICommandService<Rh, RhDto> c)
          : base(q, c) { }
    }

}
