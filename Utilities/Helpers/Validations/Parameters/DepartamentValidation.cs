using Entity.Dtos.Parameters.Departament;
using FluentValidation;
//using System.Linq;

namespace Utilities.Helpers.Validations.Parameters
{
    public class DepartamentValidation : AbstractValidator<DepartamentDto>
    {
        public DepartamentValidation()
        {
            RuleSet("Full", () =>
            {
                RuleFor(x => x.Status)
                .InclusiveBetween(0, 5)
                .WithMessage("El estado debe estar entre 0 y 5.");

                RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .Must(s => !string.IsNullOrWhiteSpace(s))
                    .WithMessage("El nombre no puede ser solo espacios.")
                .Matches(@"^[\p{L}\s'\-]+$") // letras Unicode + espacios + ' y -
                    .WithMessage("El nombre solo puede contener letras y espacios (sin números).")
                 .MinimumLength(4).WithMessage("El nombre debe tener al menos 4 caracteres.")
                 .MaximumLength(15).WithMessage("El nombre no puede exceder 15 caracteres.");

            });

            // Reglas para PATCH: solo valida si el campo viene presente
            RuleSet("Patch", () =>
            {
                RuleFor(x => x.Id).NotEmpty().WithMessage("El Id es obligatorio");

            });
            

            


        }
    }
}
