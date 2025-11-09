using Entity.Dtos.Business.GroupDirector;
using Entity.Dtos.Parameters.Group;
using FluentValidation;
using Utilities.Helpers.Validations.ValidationsGenerics;

namespace Utilities.Helpers.Validations.Business
{
    public class GroupDirectorValidation : AbstractValidator<GroupDirectorDto>
    {
        public GroupDirectorValidation()
        {
            RuleSet("Full", () =>
            {

                RuleFor(x => x.TeacherId)
                    .GreaterThan(0)
                    .WithMessage("El id de la agenda no es valido.")
                    .NotEmpty().WithMessage("El id de la agenda es obligatorio");

            });

            // Reglas para PATCH: solo valida si el campo viene presente
            RuleSet("Patch", () =>
            {
                RuleFor(x => x.Id).NotEmpty().WithMessage("El Id es obligatorio");

            });
           
        }


    }
    
}
