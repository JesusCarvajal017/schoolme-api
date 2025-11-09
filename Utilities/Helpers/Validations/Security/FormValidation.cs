using Entity.Dtos.Security.Form;
using FluentValidation;
using Utilities.Helpers.Validations.ValidationsGenerics;

namespace Utilities.Helpers.Validations.Security
{
    public class DataBasicValidation : AbstractValidator<FormDto>
    {
        public DataBasicValidation()
        {

            RuleSet("Full", () =>
            {
                RuleFor(x => x.Name).StandardName(min: 4, max: 15);


                RuleFor(x => x.Description)
                    .NotEmpty().WithMessage("La descripcion es obligatoria");

            });

            // Reglas para PATCH: solo valida si el campo viene presente
            RuleSet("Patch", () =>
            {
                RuleFor(x => x.Id).NotEmpty().WithMessage("El Id es obligatorio");

            });

        }
    }
}
