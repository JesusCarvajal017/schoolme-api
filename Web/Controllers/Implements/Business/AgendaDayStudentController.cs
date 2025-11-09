using Business.Interfaces.Commands;
using Business.Interfaces.Querys;
using Entity.Dtos.Business.AgendaDayStudent;
using Entity.Model.Business;
using Web.Controllers.Implements.Abstract;

namespace Web.Controllers.Implements.Business
{
    public class AgendaDayStudentController
       : GenericController<
       AgendaDayStudent,
       AgendaDayStudentDto,
       AgendaDayStudentDto>
    {
        public AgendaDayStudentController(
            IQueryServices<AgendaDayStudent, AgendaDayStudentDto> q,
            ICommandService<AgendaDayStudent, AgendaDayStudentDto> c)
          : base(q, c) { }
    }

}
