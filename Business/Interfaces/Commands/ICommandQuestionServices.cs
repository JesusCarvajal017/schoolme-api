using Business.Interfaces.Commands;
using Entity.Dtos.Business.Question;
using Entity.Model.Business;

namespace Business.Interfaces.Querys
{
    public interface ICommandQuestionServices : ICommandService<Question, QuestionDto>
    {
       

    }
}
