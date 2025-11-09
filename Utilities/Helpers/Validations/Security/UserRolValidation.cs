using Entity.Dtos.Security.User;
using Entity.Dtos.Security.UserRol;
using FluentValidation;

namespace Utilities.Helpers.Validations.Security
{
    public class UserRolValidation : AbstractValidator<UserRolCreateDtos>
    {
        public UserRolValidation() 
        {

            RuleSet("Full", () =>
            {
                RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("El id del usuario debe ser obligatorio");

                RuleFor(x => x.RolId)
               .NotEmpty().WithMessage("El id del rol es obligatorio");

            });

            // Reglas para PATCH: solo valida si el campo viene presente
            RuleSet("Patch", () =>
            {
                RuleFor(x => x.Id).NotEmpty().WithMessage("El Id es obligatorio");

            });
          
        }
    }
}
