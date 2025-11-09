using Entity.Dtos.Business.StudentAnswareOption;
using FluentValidation;

namespace Utilities.Helpers.Validations.Business
{
    public class StudentsAnswareOptionValidation : AbstractValidator<StudentAnswareOptionDto>
    {
        public StudentsAnswareOptionValidation()
        {
           

            RuleSet("Full", () =>
            {
                RuleFor(x => x.StudentAnswerId)
                     .GreaterThan(0)
                     .GreaterThan(0)
                    .WithMessage("El id de grupo no es valido.")
                    .NotEmpty().WithMessage("El id de grupo es obligatorio");

            });

            // Reglas para PATCH: solo valida si el campo viene presente
            RuleSet("Patch", () =>
            {
                RuleFor(x => x.Id).NotEmpty().WithMessage("El Id es obligatorio");

            });
        }


    }
    
}
