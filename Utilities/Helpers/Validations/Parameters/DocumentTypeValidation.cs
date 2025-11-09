using Entity.Dtos.Parameters.DocumentType;
using Entity.Dtos.Security.Form;
using FluentValidation;

namespace Utilities.Helpers.Validations.Parameters
{
    public class DocumentTypeValidation : AbstractValidator<DocumentTypeDto>
    {
        public DocumentTypeValidation()
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

                RuleFor(x => x.Acronym)
                   .Cascade(CascadeMode.Stop)
                   .Must(s => !string.IsNullOrWhiteSpace(s))
                       .WithMessage("El acrónimo es obligatorio.")
                   .Length(2, 4)
                       .WithMessage("El acrónimo debe tener entre 2 y 4 caracteres.")
                   // Solo letras (Unicode) y el punto. Sin dígitos ni otros símbolos/espacios.
                   .Matches(@"^[\p{L}.]+$")
                       .WithMessage("El acrónimo solo puede contener letras y puntos (sin números ni otros símbolos).");

            });

            // Reglas para PATCH: solo valida si el campo viene presente
            RuleSet("Patch", () =>
            {
                RuleFor(x => x.Id).NotEmpty().WithMessage("El Id es obligatorio");

            });

            

        }
    }
}
