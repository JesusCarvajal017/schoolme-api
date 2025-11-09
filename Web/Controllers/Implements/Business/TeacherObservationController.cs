using Business.Interfaces.Commands;
using Business.Interfaces.Querys;
using Entity.Dtos.Business.TeacherObservation;
using Entity.Model.Business;
using Web.Controllers.Implements.Abstract;

namespace Web.Controllers.Implements.Business
{
    public class TeacherObservationController
       : GenericController<
       TeacherObservation,
       TeacherObservationDto,
       TeacherObservationDto>
    {
        public TeacherObservationController(
            IQueryServices<TeacherObservation, TeacherObservationDto> q,
            ICommandService<TeacherObservation, TeacherObservationDto> c)
          : base(q, c) { }
    }

}
