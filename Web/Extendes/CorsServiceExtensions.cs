namespace Web.Extendes
{
    public static class CorsServiceExtensions
    {

        public static IServiceCollection AddCustomCors(this IServiceCollection services, IConfiguration configuration)
        {
            // primero intenta leer del entorno
            var originsRaw = configuration.GetValue<string>("CORS_ALLOWED_ORIGINS");

            // si no existe, toma el valor del appsettings.json
            if (string.IsNullOrWhiteSpace(originsRaw))
                originsRaw = configuration.GetValue<string>("OrigenesPermitidos");

            // evitar null para que no lance excepción
            var allowedOrigins = originsRaw?.Split(",") ?? Array.Empty<string>();

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.WithOrigins(allowedOrigins).AllowAnyHeader().AllowAnyMethod();
                });
            });

            return services;
        }
    }
}
