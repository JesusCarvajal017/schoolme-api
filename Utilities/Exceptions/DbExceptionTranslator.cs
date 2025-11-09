using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using Npgsql;

namespace Utilities.Exceptions
{
    public static class DbExceptionTranslator
    {
        public static Exception ToBusiness(DbUpdateException ex, string? operation = null, string? entityName = null)
        {
            // PostgreSQL
            if (ex.InnerException is PostgresException pg)
            {
                // Pg: https://www.postgresql.org/docs/current/errcodes-appendix.html
                return pg.SqlState switch
                {
                    "23503" => new BusinessRuleViolationException("FK_CONSTRAINT",
                               $"No se puede {Verbo(operation)} {TextoEntidad(entityName)} porque está referenciado por otros registros."), // foreign_key_violation
                    "23505" => new ValidationException("unique_constraint",
                               $"Ya existe {TextoEntidad(entityName)} con valores que deben ser únicos."), // unique_violation
                    "40001" or "40P01" => new BusinessRuleViolationException("TXN/DEADLOCK",
                               "La operación no pudo completarse por bloqueo o concurrencia. Intenta de nuevo."),
                    _ => new ExternalServiceException("Database", $"Error de base de datos ({pg.SqlState}): {pg.MessageText}", ex)
                };
            }

            // SQL Server
            if (ex.InnerException is SqlException sql)
            {
                return sql.Number switch
                {
                    547 => new BusinessRuleViolationException("FK_CONSTRAINT",
                             $"No se puede {Verbo(operation)} {TextoEntidad(entityName)} porque está referenciado por otros registros."), // FK violation
                    2627 or 2601 => new ValidationException("unique_constraint",
                             $"Ya existe {TextoEntidad(entityName)} con valores que deben ser únicos."), // unique index/constraint
                    1205 => new BusinessRuleViolationException("DEADLOCK",
                             "Se produjo un interbloqueo al procesar la solicitud. Intenta nuevamente."),
                    _ => new ExternalServiceException("Database", $"Error de base de datos ({sql.Number}).", ex)
                };
            }

            // MySQL
            if (ex.InnerException is MySqlException my)
            {
                return my.Number switch
                {
                    1451 or 1452 => new BusinessRuleViolationException("FK_CONSTRAINT",
                                  $"No se puede {Verbo(operation)} {TextoEntidad(entityName)} porque está referenciado por otros registros."), // FK
                    1062 => new ValidationException("unique_constraint",
                             $"Ya existe {TextoEntidad(entityName)} con valores que deben ser únicos."), // duplicate entry
                    1213 => new BusinessRuleViolationException("DEADLOCK",
                             "Se produjo un interbloqueo al procesar la solicitud. Intenta nuevamente."),
                    _ => new ExternalServiceException("Database", $"Error de base de datos ({my.Number}).", ex)
                };
            }

            // Genérico
            return new ExternalServiceException("Database", "Error al persistir los cambios.", ex);
        }

        private static string Verbo(string? op) => op?.ToLowerInvariant() switch
        {
            "delete" => "eliminar",
            "insert" => "crear",
            "update" => "actualizar",
            _ => "procesar"
        };

        private static string TextoEntidad(string? entity) =>
            string.IsNullOrWhiteSpace(entity) ? "el registro" : $"el {entity}";
    }
}
