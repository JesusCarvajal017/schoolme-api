using Data.Interfaces.Group.Commands;
using Entity.Context.Main;
using Entity.Dtos.Business.Student;
using Entity.Model.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data.Implements.Commands.Business
{
    public class StudentsCommandData : BaseGenericCommandsData<Student>, ICommandStudents
    {
        protected readonly ILogger<StudentsCommandData> _logger;
        protected readonly AplicationDbContext _context;

        public StudentsCommandData(AplicationDbContext context, ILogger<StudentsCommandData> logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }

        //<summary>
        // Metodo actualiza el gardo
        //</summary>
        public virtual async Task<bool> UpdateGrade(StudentsUpGrupDto dataUpdata)
        {
            try
            {
                //busqueda del usuario por nombre
                var students = await _context.Set<Student>()
                    .FirstOrDefaultAsync(u => u.Id == dataUpdata.Id);

                if (students == null)
                {
                    return false;
                }


                students.UpdatedAt = DateTime.UtcNow;
                students.GroupId = dataUpdata.GroupId;

                await _context.SaveChangesAsync();

                return true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Actalizando de grupo denegado");
                throw;
            }
        }





    }
}
