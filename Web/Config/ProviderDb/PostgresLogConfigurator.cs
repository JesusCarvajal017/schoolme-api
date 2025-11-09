using Data.Interfaces.Factory;
using Entity.Context.Log;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Web.Config.ProvideDb
{
    public class PostgresLogConfigurator : IDbEngineConfigurator
    {
        public void Configure(IServiceCollection services, IConfiguration configuration, string connectionName)
        {
            services.AddDbContext<AplicationDbContextLog>(options =>
                options.UseNpgsql(configuration.GetConnectionString(connectionName)));
        }
    }
}
