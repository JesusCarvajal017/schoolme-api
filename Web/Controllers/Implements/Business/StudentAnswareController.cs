using Business.Interfaces.Commands;
using Business.Interfaces.Querys;
using Entity.Dtos.Business.StudentAnsware;
using Entity.Model.Business;
using Web.Controllers.Implements.Abstract;

namespace Web.Controllers.Implements.Business
{
    public class StudentAnswareController
       : GenericController<
       StudentAnswer,
       StudentAnswareDto,
       StudentAnswareDto>
    {
        public StudentAnswareController(
            IQueryServices<StudentAnswer, StudentAnswareDto> q,
            ICommandService<StudentAnswer, StudentAnswareDto> c)
          : base(q, c) { }
    }

}
