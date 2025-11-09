using Business.Interfaces.Commands;
using Business.Interfaces.Querys;
using Entity.Dtos.Parameters.Group;
using Entity.Model.Paramters;
using Web.Controllers.Implements.Abstract;

namespace Web.Controllers.Implements.Parameters
{
    public class GroupsController
       : GenericController<
       Groups,
       GroupsQueryDto,
       GroupsDto>
    {
        public GroupsController(
            IQueryServices<Groups, GroupsQueryDto> q,
            ICommandService<Groups, GroupsDto> c)
          : base(q, c) { }
    }

}
