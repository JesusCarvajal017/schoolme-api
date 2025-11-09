using Entity.Dtos.Business.StudentAnsware;
using FluentValidation;

namespace Utilities.Helpers.Validations.Business
{
    public class StudentsAnswareValidation : AbstractValidator<StudentAnswareDto>
    {
        public StudentsAnswareValidation()
        {
            RuleSet("Full", () =>
            {
                RuleFor(x => x.AgendaDayStudentId)
                  .GreaterThan(0)
                    .WithMessage("El id de Agenda day student no es valido.")
                    .NotEmpty().WithMessage("El id de Agenda day student es obligatorio");

            });

            // Reglas para PATCH: solo valida si el campo viene presente
            RuleSet("Patch", () =>
            {
                RuleFor(x => x.Id).NotEmpty().WithMessage("El Id es obligatorio");

            });

            
        }


    }
    
}
