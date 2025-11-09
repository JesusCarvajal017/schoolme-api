using Entity.Dtos.Security.User;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Utilities.Helpers.Validations.Security
{
    public class UserRemasterValidation : AbstractValidator<UserCreateDto>
    {

        // Lista corta de contraseñas comunes (puedes ampliarla)
        private static readonly HashSet<string> CommonPasswords = new(StringComparer.OrdinalIgnoreCase)
        {
            "123456","123456789","qwerty","password","admin","111111","12345678","abc123"
        };

        public UserRemasterValidation() 
        {
            RuleSet("Full", () =>
            {
                RuleFor(x => x.PersonId)
                    .NotEmpty().WithMessage("El id de la persona es obligatorio");

                    RuleFor(x => x.Email)
                        .NotEmpty().WithMessage("El correo es obligatorio")
                        .EmailAddress().WithMessage("Formato de correo inválido");
            });

            // Reglas para PATCH: solo valida si el campo viene presente
            RuleSet("Patch", () =>
            {
                RuleFor(x => x.Id).NotEmpty().WithMessage("El Id es obligatorio");

            });
        }
    }
}
