using Business.Interfaces.Commands;
using Business.Interfaces.Querys;
using Entity.Dtos.Parameters.Eps;
using Entity.Model.Paramters;
using Web.Controllers.Implements.Abstract;

namespace Web.Controllers.Implements.Parameters
{
    public class EpsController
       : GenericController<
       Eps,
       EpsDto,
       EpsDto>
    {
        public EpsController(
            IQueryServices<Eps, EpsDto> q,
            ICommandService<Eps, EpsDto> c)
          : base(q, c) { }
    }

}
