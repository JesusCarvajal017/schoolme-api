using Business.Interfaces.Commands;
using Business.Interfaces.Querys;
using Entity.Dtos.Business.AgendaDay;
using Entity.Model.Business;
using Web.Controllers.Implements.Abstract;

namespace Web.Controllers.Implements.Business
{
    public class AgendaDayController
       : GenericController<
       AgendaDay,
       AgendaDayDto,
       AgendaDayDto>
    {
        public AgendaDayController(
            IQueryServices<AgendaDay, AgendaDayDto> q,
            ICommandService<AgendaDay, AgendaDayDto> c)
          : base(q, c) { }
    }

}
