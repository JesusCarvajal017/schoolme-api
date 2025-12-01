using Entity.Dtos.Business.TeacherObservation;
using FluentValidation;

namespace Utilities.Helpers.Validations.Business
{
    public class TeacherObservationValidation : AbstractValidator<TeacherObservationDto>
    {
        public TeacherObservationValidation()
        {

            RuleSet("Full", () =>
            {
                RuleFor(x => x.AgendaDayStudentId)
                 .GreaterThan(0)
                .WithMessage("El id de agendaDayStudent no es valido.")
                .NotEmpty().WithMessage("El id de agenda dia estudiante es obligatorio");

            });

            // Reglas para PATCH: solo valida si el campo viene presente
            RuleSet("Patch", () =>
            {
                RuleFor(x => x.Id).NotEmpty().WithMessage("El Id es obligatorio");

            });
           
        }


    }
    
}
