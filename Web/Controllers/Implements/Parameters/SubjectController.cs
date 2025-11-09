using Business.Interfaces.Commands;
using Business.Interfaces.Querys;
using Entity.Dtos.Parameters.Rh;
using Entity.Dtos.Parameters.Subject;
using Entity.Model.Paramters;
using Web.Controllers.Implements.Abstract;

namespace Web.Controllers.Implements.Parameters
{
    public class SubjectController
       : GenericController<
       Subject,
       SubjectDto,
       SubjectDto>
    {
        public SubjectController(
            IQueryServices<Subject, SubjectDto> q,
            ICommandService<Subject, SubjectDto> c)
          : base(q, c) { }
    }

}
