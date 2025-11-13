using Business.Interfaces.Commands;
using Business.Interfaces.Querys;
using Entity.Dtos.Business.Teacher;
using Entity.Model.Business;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Implements.Abstract;

namespace Web.Controllers.Implements.Business
{
    public class TeacherController
       : GenericController<
       Teacher,
       TeacherReadDto,
       TeacherDto>
    {
        protected readonly IQueryTeacherServices _servicesQuery;

        public TeacherController(
            IQueryTeacherServices q,
            ICommandService<Teacher, TeacherDto> c)
          : base(q, c) 
        {
            _servicesQuery = q;
        }

        // Consulta de información completa de la persona
        [HttpGet("DataBasic/{techaerId}")]
        public async Task<IActionResult> GetPersonBasic(int techaerId)
        {
            var result = await _servicesQuery.GetDataCompleteServices(techaerId);
            return Ok(result);
        }
    }

}
