using Business.Interfaces.Commands;
using Business.Interfaces.Querys;
using Entity.Dtos.Business.Student;
using Entity.Model.Business;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Implements.Abstract;

namespace Web.Controllers.Implements.Business
{
    public class StudentController
       : GenericController<
       Student,
       StudentQueryDto,
       StudentDto>
    {

        protected readonly IQueryStudentServices _servicesQuery;
        public StudentController(
            IQueryStudentServices q,
            ICommandService<Student, StudentDto> c)
          : base(q, c) 
        {
            _servicesQuery = q;
        }

        // Consulta de información completa de la persona
        [HttpGet("DataBasic/{estudentId}")]
        public async Task<IActionResult> GetPersonBasic(int estudentId)
        {
            var result = await _servicesQuery.GetDataCompleteServices(estudentId);
            return Ok(result);
        }

    }

}
