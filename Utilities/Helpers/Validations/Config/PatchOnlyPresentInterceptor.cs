using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Reflection;

public sealed class PatchOnlyPresentInterceptor : IValidatorInterceptor
{
    public IValidationContext BeforeAspNetValidation(ActionContext context, IValidationContext validationContext)
    {
        var req = context?.HttpContext?.Request;
        if (req == null || !HttpMethods.IsPatch(req.Method) || validationContext?.InstanceToValidate is null)
            return validationContext;

        var instance = validationContext.InstanceToValidate;

        // 1) Detecta qué propiedades vinieron en el body (por ModelState)
        var present = GetPresentPropertyNames(instance.GetType(), context!.ModelState).ToArray();

        // 2) Crea un nuevo ValidationContext<T> con RuleSet "Patch" + IncludeProperties(present)
        return CreateContextWithOptions(instance, present);
    }

    public ValidationResult AfterAspNetValidation(ActionContext context, IValidationContext validationContext, ValidationResult result)
        => result;

    private static HashSet<string> GetPresentPropertyNames(Type type, ModelStateDictionary modelState)
    {
        var names = new HashSet<string>(StringComparer.Ordinal);
        foreach (var kv in modelState)
        {
            var key = kv.Key;
            if (string.IsNullOrWhiteSpace(key)) continue;

            var first = key.Split('.')[0]; // por si vienen nested: "address.street"
            var pi = type.GetProperty(first, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
            if (pi != null) names.Add(pi.Name); // PascalCase real
        }
        return names;
    }

    // --- Parte clave: CreateWithOptions con el T real, sin Clone ni Composite ---
    private static IValidationContext CreateContextWithOptions(object instance, string[] props)
    {
        var mi = typeof(PatchOnlyPresentInterceptor)
            .GetMethod(nameof(CreateWithOptionsGeneric), BindingFlags.NonPublic | BindingFlags.Static)!
            .MakeGenericMethod(instance.GetType());

        return (IValidationContext)mi.Invoke(null, new object[] { instance, props })!;
    }

    private static IValidationContext CreateWithOptionsGeneric<T>(T instance, string[] props)
        => ValidationContext<T>.CreateWithOptions(instance, o =>
        {
            o.IncludeRuleSets("Patch");
            o.IncludeProperties(props);
        });
}
