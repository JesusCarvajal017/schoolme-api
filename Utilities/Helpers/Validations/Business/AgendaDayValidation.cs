using Entity.Dtos.Business.AgendaDay;
using FluentValidation;

namespace Utilities.Helpers.Validations.Business
{
    public class AgendaDayValidation : AbstractValidator<AgendaDayDto>
    {
        public AgendaDayValidation()
        {
            RuleSet("Full", () =>
            {
                RuleFor(x => x.AgendaId)
                .GreaterThan(0)
                .WithMessage("El id de la agenda no es valido.")
                .NotEmpty().WithMessage("El id de la persona es obligatorio");
            });

            // Reglas para PATCH: solo valida si el campo viene presente
            RuleSet("Patch", () =>
            {
                RuleFor(x => x.Id).NotEmpty().WithMessage("El Id es obligatorio");

            });

            
        }


    }
    
}
