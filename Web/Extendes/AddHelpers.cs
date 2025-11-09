using FluentValidation;
using FluentValidation.AspNetCore;
using Utilities.Helpers.Validations;
using Utilities.Helpers.Validations.implemets;
using Utilities.Helpers.Validations.Security;

namespace Web.Extendes
{
    public static class AddHelpers
    {
        public static IServiceCollection AddHelpersValidation(this IServiceCollection services)
        {
            services.AddScoped<IGenericHerlpers, GenericHelpers>();
            services.AddValidatorsFromAssemblyContaining<UserValidation>();
            services.AddFluentValidationAutoValidation();


            services
            .AddFluentValidationAutoValidation()
            .AddFluentValidationClientsideAdapters();

            // Tus validators (ejemplo):
            // builder.Services.AddTransient<IValidator<FormDto>, DataBasicValidation>();

            services.AddTransient<IValidatorInterceptor, PatchOnlyPresentInterceptor>();

            return services;

        }
    }
}
