using Business.Interfaces.Commands;
using Business.Interfaces.Querys;
using Entity.Dtos.Business.GroupDirector;
using Entity.Model.Business;
using Web.Controllers.Implements.Abstract;

namespace Web.Controllers.Implements.Business
{
    public class QuestionOptionController
       : GenericController<
       GroupDirector,
       GroupDirectorDto,
       GroupDirectorDto>
    {
        public QuestionOptionController(
            IQueryServices<GroupDirector, GroupDirectorDto> q,
            ICommandService<GroupDirector, GroupDirectorDto> c)
          : base(q, c) { }
    }

}
