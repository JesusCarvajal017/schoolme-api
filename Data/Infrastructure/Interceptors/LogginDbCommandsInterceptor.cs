using Entity.Context.Log;
using Entity.Model.Auditoria;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using System.Data.Common;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace Data.Infrastructure.Interceptors
{
    public class LogginDbCommandsInterceptor : DbCommandInterceptor
    {
        private readonly IServiceProvider _serviceProvider;
        //private readonly IHttpContextAccessor _httpContextAccessor;

        public LogginDbCommandsInterceptor(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            //_httpContextAccessor = httpContextAccessor;
        }

        //private string ObtenerUsuarioActual()
        //{
        //    var user = _httpContextAccessor.HttpContext?.User;
        //    if (user?.Identity?.IsAuthenticated == true)
        //        return user.Identity.Name!;
        //    return "Anonymous";
        //}

        // 1) Antes de ejecutar un SELECT (intercepta el comando justo antes de enviarlo al servidor):
        public override ValueTask<InterceptionResult<DbDataReader>> ReaderExecutingAsync(
            DbCommand command,
            CommandEventData eventData,
            InterceptionResult<DbDataReader> result,
            CancellationToken cancellationToken = default)
        {
         

            // Simplemente devolvemos el “resultado” para que EF siga con la ejecución normal:
            return base.ReaderExecutingAsync(command, eventData, result, cancellationToken);
        }

        // 2) Después de ejecutar un SELECT (intercepta el resultado que devuelve EF Core):
        public override async ValueTask<DbDataReader> ReaderExecutedAsync(
            DbCommand command,
            CommandExecutedEventData eventData,
            DbDataReader result,
            CancellationToken cancellationToken = default)
        {
            var duracionMs = (long)eventData.Duration.TotalMilliseconds;
            await RegistrarLogAsync(command, eventData, "SELECT", duracionMs);

            return await base.ReaderExecutedAsync(command, eventData, result, cancellationToken);
        }

        // 3) Antes de ejecutar INSERT/UPDATE/DELETE (pre‐ejecución de DML):
        public override async ValueTask<InterceptionResult<int>> NonQueryExecutingAsync(
            DbCommand command,
            CommandEventData eventData,
            InterceptionResult<int> result,
            CancellationToken cancellationToken = default)
        {
            return await base.NonQueryExecutingAsync(command, eventData, result, cancellationToken);
        }

        // 4) Después de ejecutar INSERT/UPDATE/DELETE (post‐ejecución de DML):
        public override async ValueTask<int> NonQueryExecutedAsync(
            DbCommand command,
            CommandExecutedEventData eventData,
            int result,
            CancellationToken cancellationToken = default)
        {
            var duracionMs = (long)eventData.Duration.TotalMilliseconds;
            await RegistrarLogAsync(command, eventData, "NonQuery", duracionMs);
            return await base.NonQueryExecutedAsync(command, eventData, result, cancellationToken);
        }

        // 5) Para operaciones que devuelven un scalar (ej. COUNT, SUM, etc.)
        public override async ValueTask<InterceptionResult<object>> ScalarExecutingAsync(
            DbCommand command,
            CommandEventData eventData,
            InterceptionResult<object> result,
            CancellationToken cancellationToken = default)
        {
            return await base.ScalarExecutingAsync(command, eventData, result, cancellationToken);
        }

        public override async ValueTask<object> ScalarExecutedAsync(
            DbCommand command,
            CommandExecutedEventData eventData,
            object result,
            CancellationToken cancellationToken = default)
        {
            var tipoOp = ExtraerOperacion(command.CommandText);
            var duracionMs = (long)eventData.Duration.TotalMilliseconds;
            await RegistrarLogAsync(command, eventData, tipoOp, duracionMs);

            return await base.ScalarExecutedAsync(command, eventData, result, cancellationToken);
        }

        // 6) Método común para extraer la operación del SQL (INSERT, UPDATE, DELETE o SELECT):
            private string ExtraerOperacion(string sql)
            {
                // Elimina espacios iniciales y convierte en mayúscula
                sql = sql.TrimStart().ToUpperInvariant();

                // Buscar las operaciones típicas al inicio del SQL
                var match = Regex.Match(sql, @"\b(SELECT|INSERT|UPDATE|DELETE|MERGE|EXEC|WITH)\b", RegexOptions.IgnoreCase);

                if (match.Success)
                    return match.Groups[1].Value.ToUpperInvariant();

                return "DESCONOCIDO";
            }



        // 7) Método para guardar el Log en la base de auditoría
        private async Task RegistrarLogAsync(
            DbCommand command,
            CommandExecutedEventData eventData,
            string operationType,
            long durationMs)
        {
            try
            {
                using var scope = _serviceProvider.CreateScope();
                var logContext = scope.ServiceProvider.GetRequiredService<AplicationDbContextLog>();

                // Serializamos los parámetros a JSON (si lo deseas)
                var parametrosJson = JsonSerializer.Serialize(
                    command.Parameters.Cast<DbParameter>().Select(p => new
                    {
                        p.ParameterName,
                        p.Value,
                        p.DbType,
                        p.Direction,
                        p.IsNullable
                }));

                var entry = new Auditoria
                {
                    Timestamp = DateTime.UtcNow,
                    OperationType = operationType,
                    CommandText = command.CommandText,
                    ParametersJson = parametrosJson,
                    AffectedEntities = ExtraerEntidadesAfectadas(command.CommandText), // O parsea el SQL para extraer tablas si lo necesitas
                    DurationMs = durationMs
                };

                logContext.Log.Add(entry);
                await logContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                // Captura el error de logging para no romper la operación principal.
                // Podrías escribir en un archivo o en un logger aparte si quieres.
            }
        }

        private string ExtraerEntidadesAfectadas(string sql)
        {
            var palabras = sql.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (palabras.Length >= 2)
            {
                if (palabras[0].Equals("INSERT", StringComparison.OrdinalIgnoreCase) && palabras[1].Equals("INTO", StringComparison.OrdinalIgnoreCase))
                    return palabras[2];
                if (palabras[0].Equals("UPDATE", StringComparison.OrdinalIgnoreCase) ||
                    palabras[0].Equals("DELETE", StringComparison.OrdinalIgnoreCase))
                    return palabras[1];
                if (palabras[0].Equals("SELECT", StringComparison.OrdinalIgnoreCase))
                    return "Consulta"; // O intenta identificar las tablas involucradas en el FROM
            }
            return "Desconocido";
        }

        //private string ExtraerOperacion(string sql)
        //{
        //    var primeraPalabra = sql.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries).FirstOrDefault();
        //    return primeraPalabra?.ToUpperInvariant() ?? "DESCONOCIDO";
        //}


    }
}
