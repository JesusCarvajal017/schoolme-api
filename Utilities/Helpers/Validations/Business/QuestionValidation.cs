using Entity.Dtos.Business.Question;
using FluentValidation;

namespace Utilities.Helpers.Validations.Business
{
    public class QuestionValidation : AbstractValidator<QuestionDto>
    {
        public QuestionValidation()
        {

            RuleSet("Full", () =>
            {
                RuleFor(x => x.Text)
                .NotEmpty().WithMessage("El enunciado del la pregunta es obligatorio");

            });

            // Reglas para PATCH: solo valida si el campo viene presente
            RuleSet("Patch", () =>
            {
                RuleFor(x => x.Id).NotEmpty().WithMessage("El Id es obligatorio");

            });
           
            
            
        }


    }
    
}
