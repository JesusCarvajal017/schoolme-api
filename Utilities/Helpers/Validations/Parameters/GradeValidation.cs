using Entity.Dtos.Parameters.Grade;
using FluentValidation;
using Utilities.Helpers.Validations.ValidationsGenerics;

namespace Utilities.Helpers.Validations.Parameters
{
    public class GradeValidation : AbstractValidator<GradeDto>
    {
        public GradeValidation()
        {
            RuleSet("Full", () =>
            {
                RuleFor(x => x.Name).StandardName(min: 4, max: 20);

            });

            // Reglas para PATCH: solo valida si el campo viene presente
            RuleSet("Patch", () =>
            {
                RuleFor(x => x.Id).NotEmpty().WithMessage("El Id es obligatorio");

            });


        }
    }
}
