using Entity.Dtos.Security.RolFormPermission;
using FluentValidation;

namespace Utilities.Helpers.Validations.Security
{
    public class RolFormPermissionCreateValidation : AbstractValidator<RolFormPermissionCreateDto>
    {
        public RolFormPermissionCreateValidation()
        {

            RuleSet("Full", () =>
            {
                RuleFor(x => x.RolId)
                  .NotEmpty().WithMessage("El id del rol es obligatorio");

                RuleFor(x => x.FormId)
                    .NotEmpty().WithMessage("El Id form es obligatoria");
            });

            // Reglas para PATCH: solo valida si el campo viene presente
            RuleSet("Patch", () =>
            {
                RuleFor(x => x.Id).NotEmpty().WithMessage("El Id es obligatorio");

            });

        }
    }
}
