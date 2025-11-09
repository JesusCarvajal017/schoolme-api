using Business.Interfaces.Commands;
using Business.Interfaces.Querys;
using Entity.Dtos.Parameters.Grade;
using Entity.Model.Paramters;
using Web.Controllers.Implements.Abstract;

namespace Web.Controllers.Implements.Parameters
{
    public class GradeController
       : GenericController<
       Grade,
       GradeDto,
       GradeDto>
    {
        public GradeController(
            IQueryServices<Grade, GradeDto> q,
            ICommandService<Grade, GradeDto> c)
          : base(q, c) { }
    }

}
