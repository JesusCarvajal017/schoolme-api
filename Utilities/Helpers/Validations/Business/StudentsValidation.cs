using Entity.Dtos.Business.Student;
using FluentValidation;

namespace Utilities.Helpers.Validations.Business
{
    public class StudentsValidation : AbstractValidator<StudentDto>
    {
        public StudentsValidation()
        {
            RuleSet("Full", () =>
            {
                RuleFor(x => x.PersonId)
                  .GreaterThan(0)
                    .WithMessage("El id de la persona no es valido.")
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
