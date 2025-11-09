using System.Net;
using System.Text.Json;
using Utilities.Exceptions;

namespace Web.Middlewares
{
    public class ProblemDetailsMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ProblemDetailsMiddleware> _logger;

        public ProblemDetailsMiddleware(RequestDelegate next, ILogger<ProblemDetailsMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await Handle(context, ex);
            }
        }

        private async Task Handle(HttpContext ctx, Exception ex)
        {
            var (status, title, type) = ex switch
            {
                EntityNotFoundException => (HttpStatusCode.NotFound, "Recurso no encontrado", "https://httpstatuses.com/404"),
                ValidationException => (HttpStatusCode.BadRequest, "Error de validación", "https://httpstatuses.com/400"),
                BusinessRuleViolationException => (HttpStatusCode.UnprocessableEntity, "Regla de negocio violada", "https://httpstatuses.com/422"),
                UnauthorizedAccessBusinessException => (HttpStatusCode.Forbidden, "Acceso no autorizado", "https://httpstatuses.com/403"),
                ExternalServiceException => (HttpStatusCode.ServiceUnavailable, "Servicio externo no disponible", "https://httpstatuses.com/503"),
                BusinessException => (HttpStatusCode.BadRequest, "Error de negocio", "about:blank"),
                _ => (HttpStatusCode.InternalServerError, "Error interno del servidor", "https://httpstatuses.com/500")
            };

            if ((int)status >= 500)
                _logger.LogError(ex, "Excepción no controlada");
            else
                _logger.LogWarning(ex, "Excepción controlada");

            var problem = new
            {
                type,
                title,
                status = (int)status,
                detail = ex.Message,
                traceId = ctx.TraceIdentifier
            };

            ctx.Response.ContentType = "application/problem+json";
            ctx.Response.StatusCode = (int)status;
            await ctx.Response.WriteAsync(JsonSerializer.Serialize(problem));
        }
    }
}
