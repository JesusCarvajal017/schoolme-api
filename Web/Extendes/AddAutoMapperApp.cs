namespace Web.Extendes
{
    public static class AddAutoMapperApp
    {
        public static IServiceCollection AddMapperApp(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Utilities.MappersApp.security.UserMap));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;

        }
    }
}
