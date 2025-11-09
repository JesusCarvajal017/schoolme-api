using Entity.Dtos.Security.ModuleForm;
using FluentValidation;

namespace Utilities.Helpers.Validations.Security
{
    public class ModuleFormValidation : AbstractValidator<ModuleFormCreation>
    {
        public ModuleFormValidation()
        {
            RuleSet("Full", () =>
            {
                RuleFor(x => x.ModuleId)
                .NotEmpty().WithMessage("El id del modulo es obligatorio");

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
