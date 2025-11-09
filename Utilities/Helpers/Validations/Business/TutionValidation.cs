using Entity.Dtos.Business.Tution;
using FluentValidation;

namespace Utilities.Helpers.Validations.Business
{
    public class TutionValidation : AbstractValidator<TutionDto>
    {
        public TutionValidation()
        {

            RuleSet("Full", () =>
            {
                RuleFor(x => x.StudentId)
                 .GreaterThan(0)
                .WithMessage("El id de estudiante no es valido.")
                .NotEmpty().WithMessage("El id de estudiante es obligatorio");

                RuleFor(x => x.GradeId)
                .GreaterThan(0)
                   .WithMessage("El id de grado no es valido.")
                   .NotEmpty().WithMessage("El id de grado es obligatorio");

            });

            // Reglas para PATCH: solo valida si el campo viene presente
            RuleSet("Patch", () =>
            {
                RuleFor(x => x.Id).NotEmpty().WithMessage("El Id es obligatorio");

            });
           
        }


    }
    
}
