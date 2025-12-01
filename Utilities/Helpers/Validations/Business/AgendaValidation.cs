using Entity.Dtos.Business.Agenda;
using FluentValidation;
using Utilities.Helpers.Validations.ValidationsGenerics;

namespace Utilities.Helpers.Validations.Business
{
    public class AgendaValidation : AbstractValidator<AgendaDto>
    {
        public AgendaValidation()
        {
            RuleSet("Full", () =>
            {
                RuleFor(x => x.Name).StandardName(min: 4, max: 150);

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
