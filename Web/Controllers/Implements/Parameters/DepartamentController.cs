using Business.Interfaces.Commands;
using Business.Interfaces.Querys;
using Entity.Dtos.Parameters.Departament;
using Entity.Model.Paramters;
using Web.Controllers.Implements.Abstract;

namespace Web.Controllers.Implements.Parameters
{
    public class DepartamentController
       : GenericController<
       Departament,
       DepartamentDto,
       DepartamentDto>
    {
        public DepartamentController(
            IQueryServices<Departament, DepartamentDto> q,
            ICommandService<Departament, DepartamentDto> c)
          : base(q, c) { }
    }

}
