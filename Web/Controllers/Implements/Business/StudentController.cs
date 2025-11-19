using Business.Interfaces.Commands;
using Business.Interfaces.Querys;
using Entity.Dtos.Business.Student;
using Entity.Model.Business;
using FluentValidation.AspNetCore;
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
        protected readonly ICommandStudentsServices _servicesCommand;
        public StudentController(
            IQueryStudentServices q,
            ICommandStudentsServices c)
          : base(q, c) 
        {
            _servicesQuery = q;
            _servicesCommand = c;
        }

        // Consulta de información completa de la persona
        [HttpGet("DataBasic/{estudentId}")]
        public async Task<IActionResult> GetPersonBasic(int estudentId)
        {
            var result = await _servicesQuery.GetDataCompleteServices(estudentId);
            return Ok(result);
        }


        [HttpGet("MatriculationNot")]
        public async Task<IActionResult> ServicesNotMatriculate()
        {
            var result = await _servicesQuery.GetNotMatriculados();
            return Ok(result);
        }

        [HttpGet("StudentsGroup/{groupId}")]
        public async Task<IActionResult> ServicesStudentsGroup(int groupId)
        {
            var result = await _servicesQuery.GetStudentsGroup(groupId);
            return Ok(result);
        }

        [HttpPost("ChangeGroup")]
        public virtual async Task<IActionResult> Create([FromBody] StudentsUpGrupDto dto)
        {
            var created = await _servicesCommand.ChangeGrupServices(dto);
            return Ok(created);
        }






    }

}
