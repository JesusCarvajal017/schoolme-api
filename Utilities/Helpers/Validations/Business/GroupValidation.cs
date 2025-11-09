using Entity.Dtos.Parameters.Group;
using FluentValidation;
using Utilities.Helpers.Validations.ValidationsGenerics;

namespace Utilities.Helpers.Validations.Business
{
    public class GroupValidation : AbstractValidator<GroupsDto>
    {
        public GroupValidation()
        {
            RuleSet("Full", () =>
            {
                RuleFor(x => x.Name).StandardName(min: 4, max: 15);
                //RuleFor(x => x.AgendaId)
                //    .GreaterThan(0)
                //    .WithMessage("El id de la agenda no es valido.")
                //    .NotEmpty().WithMessage("El id de la agenda es obligatorio");

            });

            // Reglas para PATCH: solo valida si el campo viene presente
            RuleSet("Patch", () =>
            {
                RuleFor(x => x.Id).NotEmpty().WithMessage("El Id es obligatorio");

            });
           
        }


    }
    
}
