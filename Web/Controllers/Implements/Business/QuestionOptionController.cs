using Business.Interfaces.Commands;
using Business.Interfaces.Querys;
using Entity.Dtos.Business.QuestionOption;
using Entity.Model.Business;
using Web.Controllers.Implements.Abstract;

namespace Web.Controllers.Implements.Business
{
    public class QuestionOptionController
       : GenericController<
       QuestionOption,
       QuestionOptionDto,
       QuestionOptionDto>
    {
        public QuestionOptionController(
            IQueryServices<QuestionOption, QuestionOptionDto> q,
            ICommandService<QuestionOption, QuestionOptionDto> c)
          : base(q, c) { }
    }

}
