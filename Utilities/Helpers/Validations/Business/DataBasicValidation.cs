using Entity.Dtos.Business.DataBasic;
using FluentValidation;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Utilities.Helpers.Validations.Business
{
    public class DataBasicValidation : AbstractValidator<DataBasicDto>
    {

        private static readonly Regex AddressCoRegex = new Regex(
             @"^\s*(?:Cl|Calle|Cra|Carrera|Av|Avenida|Tv|Transv|Transversal|Dg|Diagonal|Autop(?:ista)?)\.?\s+\d{1,3}[A-Z]?(?:\s*(?:Sur|Norte|Este|Oeste|Occidente))?\s*(?:No\.?|#)\s*\d{1,3}[A-Z]?\s*-\s*\d{1,3}(?:\s*(?:Int\.?|Interior|Apto\.?|Apartamento|Of\.?|Oficina|Torre|Piso)\s*[\p{L}\p{N}_-]+)*\s*$",
             RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase
         );

        public DataBasicValidation()
        {

            RuleSet("Full", () =>
            {
                RuleFor(x => x.PersonId)
                .GreaterThan(0)
                 .WithMessage("El id de la persona no es valido.")
                .NotEmpty().WithMessage("El id de la persona es obligatorio");

                RuleFor(x => x.RhId)
                    .GreaterThan(0)
                     .WithMessage("El id de rh no es valido.")
                    .NotEmpty().WithMessage("El id del rh es obligatorio");

                RuleFor(x => x.Status)
                    .InclusiveBetween(0, 5)
                    .WithMessage("El estado debe estar entre 0 y 5.");

                RuleFor(x => x.Adress)
                  .Cascade(CascadeMode.Stop)
                  // Obligatoria (no nula/espacios)
                  .Must(v => !string.IsNullOrWhiteSpace(v))
                      .WithMessage("La dirección es obligatoria.")
                  // Longitud 8–100 considerando Trim
                  .Must(v => {
                      var s = v!.Trim();
                      return s.Length >= 8 && s.Length <= 100;
                  })
                      .WithMessage("La dirección debe tener entre 8 y 100 caracteres.")

                  // Formato (evaluado sobre el Trim)
                  .Must(v => AddressCoRegex.IsMatch(v!.Trim()))
                      .WithMessage("Formato inválido. Ejemplos: 'Cra 15 # 85-24', 'Calle 100 # 8A-55'.");


                RuleFor(x => x.BrithDate)
                 .NotNull().WithMessage("La fecha de nacimiento es obligatoria.")
                 .LessThan(DateTime.Today).WithMessage("La fecha de nacimiento debe ser anterior a hoy.")
                 .GreaterThan(new DateTime(1900, 1, 1)).WithMessage("La fecha de nacimiento no puede ser anterior a 1900.");

                RuleFor(x => x.StratumStatus)
                    .InclusiveBetween(0, 5)
                    .WithMessage("Los valores validos debe estar entre 0 y 5.");

                RuleFor(x => x.EpsId)
                    .GreaterThan(0)
                     .WithMessage("El id de la eps no es valido.")
                .NotEmpty().WithMessage("El id de la eps es obligatorio");

                RuleFor(x => x.MunisipalityId)
                       .GreaterThan(0)
                        .WithMessage("El id del municipio no es valido.")
                   .NotEmpty().WithMessage("El id del municipio es obligatorio");

            });

            // Reglas para PATCH: solo valida si el campo viene presente
            RuleSet("Patch", () =>
            {
                RuleFor(x => x.Id).NotEmpty().WithMessage("El Id es obligatorio");

            });
            
        }


    }

     
    
    
}
