using Entity.Dtos.Business.AgendaDayStudent;
using FluentValidation;

namespace Utilities.Helpers.Validations.Business
{
    public class AgendaDayStudentValidation : AbstractValidator<AgendaDayStudentDto>
    {
        public AgendaDayStudentValidation()
        {
            RuleSet("Full", () =>
            {
                RuleFor(x => x.AgendaDayId)
                .GreaterThan(0)
                .WithMessage("El id de la agenda day no es valido.")
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
