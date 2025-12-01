using Entity.Model.Business;

namespace Data.Interfaces.Group.Commands
{
    public interface ICommandQuestion : ICommands<Question>
    {
        Task<Question> InsertWithOptionsAsync(Question entity, IEnumerable<QuestionOption> options);
    }
}
