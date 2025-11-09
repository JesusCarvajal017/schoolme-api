using Business.Interfaces.Commands;
using Business.Interfaces.Querys;
using Entity.Dtos.Business.Tution;
using Entity.Model.Business;
using Web.Controllers.Implements.Abstract;

namespace Web.Controllers.Implements.Business
{
    public class TutionController
       : GenericController<
       Tutition,
       TutionReadDto,
       TutionDto>
    {
        public TutionController(
            IQueryServices<Tutition, TutionReadDto> q,
            ICommandService<Tutition, TutionDto> c)
          : base(q, c) { }
    }

}
