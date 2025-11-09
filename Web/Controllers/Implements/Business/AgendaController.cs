using Business.Interfaces.Commands;
using Business.Interfaces.Querys;
using Entity.Dtos.Business.Agenda;
using Entity.Model.Business;
using Web.Controllers.Implements.Abstract;

namespace Web.Controllers.Implements.Business
{
    public class AgendaController
       : GenericController<
       Agenda,
       AgendaDto,
       AgendaDto>
    {
        public AgendaController(
            IQueryServices<Agenda, AgendaDto> q,
            ICommandService<Agenda, AgendaDto> c)
          : base(q, c) 
        {
            
        }



    }

}
