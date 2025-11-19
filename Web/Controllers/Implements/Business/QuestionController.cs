using Business.Interfaces.Commands;
using Business.Interfaces.Querys;
using Entity.Dtos.Business.Question;
using Entity.Model.Business;
using Web.Controllers.Implements.Abstract;

namespace Web.Controllers.Implements.Business
{
    public class QuestionController
       : GenericController<
       Question,
       QuestionQueryDto,
       QuestionDto>
    {
        public QuestionController(
            IQueryServices<Question, QuestionQueryDto> q,
            ICommandService<Question, QuestionDto> c)
          : base(q, c) { }
    }

}
