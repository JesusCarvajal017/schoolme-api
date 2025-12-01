using AutoMapper;
using Business.Implements.Bases;
using Business.Interfaces.Querys;
using Data.Interfaces.Group.Commands;
using Entity.Context.Main;
using Entity.Dtos.Business.Student;
using Entity.Model.Business;
using Microsoft.Extensions.Logging;
using Utilities.Helpers.Validations;

namespace Business.Implements.Commands.Business
{
    public class StudentsCommandBusines : BaseCommandsBusiness<Student, StudentDto>, ICommandStudentsServices
    {
        protected readonly ICommandStudents _data;


        public StudentsCommandBusines(
            ICommandStudents data,
            IMapper mapper,
            ILogger<StudentsCommandBusines> _logger,
            IGenericHerlpers helpers,
            AplicationDbContext context
            ) : base(data, mapper, _logger, helpers, context)
        {
            _data = data;
        }

   
        public virtual async Task<bool> ChangeGrupServices(StudentsUpGrupDto dataUpdate)
        {
            try
            {
                return await _data.UpdateGrade(dataUpdate);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar la contraseña de la persona {dataUpdate.Id}");
                throw;
            }
        }



    }
}
