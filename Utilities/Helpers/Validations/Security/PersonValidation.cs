using Entity.Dtos.Security.Person;
using FluentValidation;
using Utilities.Helpers.Validations.ValidationsGenerics;

namespace Utilities.Helpers.Validations.Security
{
    public class PersonValidator : AbstractValidator<PersonDto>
    {
        private const long Min6Digits = 100_000L;          // 6 dígitos
        private const long Max12Digits = 999_999_999_999L; // 12 dígitos
        public PersonValidator()
        {

            RuleSet("Full", () =>
            {
                RuleFor(x => x.DocumentTypeId)
               .GreaterThan(0)
                .WithMessage("El id de rh no es valido.")
               .NotEmpty().WithMessage("El id del rh es obligatorio");

                RuleFor(x => x.Identification)
                .InclusiveBetween(Min6Digits, Max12Digits)
                .WithMessage("Debe tener entre 6 y 12 dígitos (sin ceros a la izquierda).");


                RuleFor(x => x.FisrtName).StandardName(min: 4, max: 30);


                RuleFor(x => x.FisrtName)
                    .Cascade(CascadeMode.Stop)
                    .Must(s => !string.IsNullOrWhiteSpace(s))
                        .WithMessage("El nombre no puede ser solo espacios.")
                    .Matches(@"^[\p{L}\s'\-]+$") // letras Unicode + espacios + ' y -
                        .WithMessage("El nombre solo puede contener letras y espacios (sin números).")
                        .MinimumLength(4).WithMessage("El nombre debe tener al menos 4 caracteres.")
                        .MaximumLength(30).WithMessage("El nombre no puede exceder 15 caracteres.");

                RuleFor(x => x.SecondName)
                   .Cascade(CascadeMode.Stop)
                   .Matches(@"^[\p{L}\s'\-]+$") // letras Unicode + espacios + ' y -
                       .WithMessage("El nombre solo puede contener letras y espacios (sin números).")
                       .MinimumLength(4).WithMessage("El nombre debe tener al menos 4 caracteres.")
                       .MaximumLength(30).WithMessage("El nombre no puede exceder 15 caracteres.");


                RuleFor(x => x.LastName)
                  .Cascade(CascadeMode.Stop)
                  .NotEmpty().WithMessage("El primer apellido es obligatorio.")
                  .Must(s => !string.IsNullOrWhiteSpace(s))
                      .WithMessage("El nombre no puede ser solo espacios.")
                  .Matches(@"^[\p{L}\s'\-]+$") // letras Unicode + espacios + ' y -
                      .WithMessage("El nombre solo puede contener letras y espacios (sin números).")
                      .MinimumLength(4).WithMessage("El nombre debe tener al menos 4 caracteres.")
                      .MaximumLength(30).WithMessage("El nombre no puede exceder 15 caracteres.");

                RuleFor(x => x.SecondLastName)
                  .Cascade(CascadeMode.Stop)
                  .Must(s => !string.IsNullOrWhiteSpace(s))
                      .WithMessage("El nombre no puede ser solo espacios.")
                  .Matches(@"^[\p{L}\s'\-]+$") // letras Unicode + espacios + ' y -
                      .WithMessage("El nombre solo puede contener letras y espacios (sin números).")
                      .MinimumLength(4).WithMessage("El nombre debe tener al menos 4 caracteres.")
                      .MaximumLength(30).WithMessage("El nombre no puede exceder 15 caracteres.");


                RuleFor(x => x.Identification)
                    .NotEmpty().WithMessage("La identificacion es obligatoria");

            });

            // Reglas para PATCH: solo valida si el campo viene presente
            RuleSet("Patch", () =>
            {
                RuleFor(x => x.Id).NotEmpty().WithMessage("El Id es obligatorio");

            });
        }
    }

        public class PersonCompleteValidation : AbstractValidator<PersonCompleteDto>
        {
            public PersonCompleteValidation()
            {
                RuleSet("Full", () =>
                {
                    RuleFor(x => x.DocumentTypeId)
                   .GreaterThan(0)
                    .WithMessage("El id de rh no es valido.")
                   .NotEmpty().WithMessage("El id del rh es obligatorio");

                    RuleFor(x => x.FisrtName)
                   .NotEmpty().WithMessage("El nombre primer nobmre debe ser obligatorio");

                    RuleFor(x => x.LastName)
                     .NotEmpty().WithMessage("El nombre primer apellido debe ser obligatorio");
                });
            }
        }
    }