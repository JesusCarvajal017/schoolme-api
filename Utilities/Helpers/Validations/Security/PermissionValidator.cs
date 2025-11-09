using Entity.Dtos.Security.Permission;
using FluentValidation;

namespace Utilities.Helpers.Validations.Security
{
    public class PermissionValidator : AbstractValidator<PermissionDto>
    {
        public PermissionValidator()
        {

            RuleSet("Full", () =>
            {
                RuleFor(x => x.Name)
              .NotEmpty().WithMessage($"El nombre del permiso es obligatorio");

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
