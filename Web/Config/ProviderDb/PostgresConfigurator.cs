using Data.Infrastructure.Interceptors;
using Data.Interfaces.Factory;
using Entity.Context.Main;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Web.Config.ProvideDb
{
    public class PostgresConfigurator : IDbEngineConfigurator
    {
        public void Configure(IServiceCollection services, IConfiguration configuration, string connectionName)
        {


            services.AddDbContext<AplicationDbContext>((servicesProvider, options) =>
            {
                var interceptor = servicesProvider.GetRequiredService<LogginDbCommandsInterceptor>();

                options.UseNpgsql(configuration.GetConnectionString(connectionName));

                options.ReplaceService<IMigrationsAssembly, NamespaceFilteredMigrationsAssembly>();

                options.AddInterceptors(interceptor);
            });

        }
    }
}
