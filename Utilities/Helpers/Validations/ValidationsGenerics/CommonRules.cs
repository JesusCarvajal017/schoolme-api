using FluentValidation;
using System.Text.RegularExpressions;


namespace Utilities.Helpers.Validations.ValidationsGenerics
{
    public static class CommonRules
    {
        //patrones de validaciones
        private const string NamePattern = @"^[\p{L}\s'\-]+$";

        // OJO: IRuleBuilderInitial en el "this"
        public static IRuleBuilderOptions<T, string?> StandardName<T>(
            this IRuleBuilderInitial<T, string?> rule,
            int min = 4, int max = 30)
        {
            return rule
                .Cascade(CascadeMode.Stop)
                .Must(s => !string.IsNullOrWhiteSpace(s))
                    .WithMessage("El nombre es obligatorio.")
                .Must(s => {
                    var t = s!.Trim();
                    return t.Length >= min && t.Length <= max;
                })
                    .WithMessage($"El nombre debe tener entre {min} y {max} caracteres.")
                .Matches(NamePattern)
                    .WithMessage("El nombre solo puede contener letras y espacios (sin números).");
        }

        public static IRuleBuilderOptions<T, string?> RequiredText<T>(
            this IRuleBuilderInitial<T, string?> rule)
        {
            return rule
                .Cascade(CascadeMode.Stop)
                .Must(s => !string.IsNullOrWhiteSpace(s))
                    .WithMessage("La descripción es obligatoria.");
        }

        // Formato de contraseña no valida, e insegura 
        private static readonly string[] CommonPasswords =
        [
            "123456", "password", "qwerty", "abc123", "111111", "123123",
            "password1", "12345678", "admin", "iloveyou"
        ];

        public static IRuleBuilderOptions<T, string?> StrongPassword<T>(
            this IRuleBuilderInitial<T, string?> rule)
        {

            return rule
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
        }



    }
}
