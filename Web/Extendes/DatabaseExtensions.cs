using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Net.Sockets;

namespace Web.Extendes
{
    public static class DatabaseExtensions
    {
        public static async Task<IHost> MigrateDatabaseAsync<TContext>(
            this IHost host,
            int maxRetries = 10,
            int delaySeconds = 3)
            where TContext : DbContext
        {
            using var scope = host.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<TContext>();
            var logger = scope.ServiceProvider.GetService<ILogger<TContext>>();

            var delay = TimeSpan.FromSeconds(delaySeconds);

            // Nota: algunos proveedores (SQL Server, Npgsql, etc.) tienen estrategia de reintentos propia.
            // La usamos para ejecutar la migración (maneja transientes específicos del proveedor).
            var strategy = db.Database.CreateExecutionStrategy();

            for (var attempt = 1; attempt <= maxRetries; attempt++)
            {
                try
                {
                    await strategy.ExecuteAsync(async () =>
                    {
                        await db.Database.MigrateAsync(); // aplica solo si faltan
                    });

                    logger?.LogInformation("Migraciones aplicadas (o no había pendientes).");
                    break; // listo
                }
                catch (Exception ex) when (attempt < maxRetries && IsTransient(ex))
                {
                    logger?.LogWarning(ex,
                        "Fallo transiente al aplicar migraciones. Reintento {Attempt}/{Max}. Esperando {Delay}s...",
                        attempt, maxRetries, delay.TotalSeconds);
                    await Task.Delay(delay);
                }
                catch (Exception ex) when (attempt < maxRetries)
                {
                    // Cualquier otro error (posiblemente DB aún no levantada)
                    logger?.LogWarning(ex,
                        "Error al aplicar migraciones. Reintento {Attempt}/{Max} en {Delay}s...",
                        attempt, maxRetries, delay.TotalSeconds);
                    await Task.Delay(delay);
                }
            }

            return host;
        }

        // Heurística de errores transientes sin amarrarse a un proveedor
        private static bool IsTransient(Exception ex)
        {
            // Desenrolla InnerExceptions
            while (ex != null)
            {
                if (ex is TimeoutException) return true;
                if (ex is SocketException) return true;    // red/puerto no listo
                if (ex is IOException) return true;        // pipe/canales
                if (ex is DbException) return true;        // base ADO.NET (SqlException, MySqlException, etc.)
                ex = ex.InnerException!;
            }
            return false;
        }
    }


}
