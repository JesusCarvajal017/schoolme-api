using Business.Interfaces.Commands;
using Business.Interfaces.Querys;
using Entity.Dtos.Business.StudentAnswareOption;
using Entity.Model.Business;
using Web.Controllers.Implements.Abstract;

namespace Web.Controllers.Implements.Business
{
    public class StudentAnswareOptionController
       : GenericController<
       StudentAnswerOption,
       StudentAnswareOptionDto,
       StudentAnswareOptionDto>
    {
        public StudentAnswareOptionController(
            IQueryServices<StudentAnswerOption, StudentAnswareOptionDto> q,
            ICommandService<StudentAnswerOption, StudentAnswareOptionDto> c)
          : base(q, c) { }
    }

}
