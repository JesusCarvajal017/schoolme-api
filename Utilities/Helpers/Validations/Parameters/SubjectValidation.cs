using Entity.Dtos.Parameters.Subject;
using FluentValidation;

namespace Utilities.Helpers.Validations.Parameters
{
    public class SubjectValidation : AbstractValidator<SubjectDto>
    {
        public SubjectValidation()
        {

            RuleSet("Full", () =>
            {
                RuleFor(x => x.Name)
                  .Cascade(CascadeMode.Stop)
                  .NotEmpty().WithMessage("El nombre es obligatorio.")
                  .Must(s => !string.IsNullOrWhiteSpace(s))
                      .WithMessage("El nombre no puede ser solo espacios.")
                  .Matches(@"^[\p{L}\s'\-]+$") // letras Unicode + espacios + ' y -
                      .WithMessage("El nombre solo puede contener letras y espacios (sin números).")
                   .MinimumLength(4).WithMessage("El nombre debe tener al menos 4 caracteres.")
                   .MaximumLength(25).WithMessage("El nombre no puede exceder 25 caracteres.");

            });

            // Reglas para PATCH: solo valida si el campo viene presente
            RuleSet("Patch", () =>
            {
                RuleFor(x => x.Id).NotEmpty().WithMessage("El Id es obligatorio");

            });
           


        }
    }
}
