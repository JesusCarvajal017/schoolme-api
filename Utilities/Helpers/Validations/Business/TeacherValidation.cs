using Entity.Dtos.Business.Teacher;
using FluentValidation;

namespace Utilities.Helpers.Validations.Business
{
    public class TeacherValidation : AbstractValidator<TeacherDto>
    {
        public TeacherValidation()
        {

            RuleSet("Full", () =>
            {
                RuleFor(x => x.PersonId)
                 .GreaterThan(0)
                .WithMessage("El id de persona no es valido.")
                .NotEmpty().WithMessage("El id de persona es obligatorio");

            });

            // Reglas para PATCH: solo valida si el campo viene presente
            RuleSet("Patch", () =>
            {
                RuleFor(x => x.Id).NotEmpty().WithMessage("El Id es obligatorio");

            });
           
        }


    }
    
}
