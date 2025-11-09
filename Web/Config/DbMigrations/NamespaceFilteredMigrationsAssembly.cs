using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;                 // 👈 importante
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Internal;

public sealed class NamespaceFilteredMigrationsAssembly : MigrationsAssembly
{
    private readonly string _nsPrefix;

    private static string ResolvePrefix()
         => (Environment.GetEnvironmentVariable("DB_ENGINE") ?? "Postgres") switch
         {
             "Postgres" or "PostgreSQL" or "Npgsql" => "Entity.Migrations.Postgres",
             "MySQL" or "MySql" => "Entity.Migrations.MySql",
             "SqlServer" or "MSSQL" => "Entity.Migrations.SqlServer",
             _ => "Entity.Migrations.Postgres"
         };

    public NamespaceFilteredMigrationsAssembly(
        ICurrentDbContext currentContext,
        IDbContextOptions options,
        IMigrationsIdGenerator idGenerator,
        IDiagnosticsLogger<DbLoggerCategory.Migrations> logger)  // ✅ tipo correcto
        : base(currentContext, options, idGenerator, logger)     // ✅ coincide con el base
    {
        _nsPrefix = ResolvePrefix();
    }

    public override IReadOnlyDictionary<string, TypeInfo> Migrations
        => base.Migrations
               .Where(kvp => kvp.Value.Namespace != null &&
                             kvp.Value.Namespace.StartsWith(_nsPrefix, StringComparison.Ordinal))
               .ToDictionary(k => k.Key, v => v.Value);

    public override ModelSnapshot? ModelSnapshot
    {
        get
        {
            var baseSnapshot = base.ModelSnapshot;
            if (baseSnapshot?.GetType().Namespace?.StartsWith(_nsPrefix, StringComparison.Ordinal) == true)
                return baseSnapshot;

            var snapType = Assembly.DefinedTypes.FirstOrDefault(t =>
                typeof(ModelSnapshot).IsAssignableFrom(t) &&
                t.Namespace != null &&
                t.Namespace.StartsWith(_nsPrefix, StringComparison.Ordinal));

            return snapType != null
                ? (ModelSnapshot?)Activator.CreateInstance(snapType.AsType())
                : null;
        }
    }
}
