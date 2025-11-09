using Entity.Dtos.Security.User;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Utilities.Helpers.Validations.Security
{
    public class UserValidation : AbstractValidator<UserDto>
    {

        // Lista corta de contraseñas comunes (puedes ampliarla)
        private static readonly HashSet<string> CommonPasswords = new(StringComparer.OrdinalIgnoreCase)
        {
            "123456","123456789","qwerty","password","admin","111111","12345678","abc123"
        };

        public UserValidation() 
        {
           

            RuleSet("Full", () =>
            {
                RuleFor(x => x.PersonId)
                    .NotEmpty().WithMessage("El id de la persona es obligatorio");

                    RuleFor(x => x.Email)
                        .NotEmpty().WithMessage("El correo es obligatorio")
                        .EmailAddress().WithMessage("Formato de correo inválido");

                    RuleFor(x => x.Password)
                    .Cascade(CascadeMode.Stop)
                    .NotEmpty().WithMessage("La contraseña es obligatoria.")
                    .MinimumLength(8).WithMessage("Debe tener al menos 8 caracteres.")
                    .MaximumLength(64).WithMessage("No puede exceder 64 caracteres.")
                    .Matches("[A-Z]").WithMessage("Debe incluir al menos una letra mayúscula.")
                    .Matches("[a-z]").WithMessage("Debe incluir al menos una letra minúscula.")
                    .Matches(@"\d").WithMessage("Debe incluir al menos un número.")
                    .Matches(@"[^\w\s]").WithMessage("Debe incluir al menos un símbolo (ej: !@#$%&*._-).")
                    .Matches(@"^\S+$").WithMessage("No se permiten espacios.")
                    .Must(p => !Regex.IsMatch(p!, @"(.)\1{2,}"))
                        .WithMessage("No repitas el mismo carácter 3 veces seguidas.")
                    .Must(p => !CommonPasswords.Contains(p!))
                        .WithMessage("La contraseña es demasiado común.");

            });

            // Reglas para PATCH: solo valida si el campo viene presente
            RuleSet("Patch", () =>
            {
                RuleFor(x => x.Id).NotEmpty().WithMessage("El Id es obligatorio");

            });
        }
    }
}
