using Data.Interfaces.Factory;
using Entity.Context.Main;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.Config.ProvideDb
{
    public class MySqlConfigurator : IDbEngineConfigurator
    {
        public void Configure(IServiceCollection services, IConfiguration configuration, string connectionName)
        {
            services.AddDbContext<AplicationDbContext>((servicesProvider, options) =>
            {
                options.UseMySQL(configuration.GetConnectionString(connectionName));
                options.ReplaceService<IMigrationsAssembly, NamespaceFilteredMigrationsAssembly>();
            });



        }
    }
}
