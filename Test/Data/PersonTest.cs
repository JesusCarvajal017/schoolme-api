using Data.Implements.Commands.Security;              // PersonCommandData
using Data.Infrastructure.Interceptors;               // LogginDbCommandsInterceptor
using Entity.Context.Main;                            // AplicationDbContext
using Entity.Enum;
using Entity.Model.Business;                          // DataBasic
using Entity.Model.Paramters;                         // Eps, Rh, Munisipality, MaterialStatus
using Entity.Model.Security;                          // Person
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Utilities.Exceptions;
using Web.Config.DataBase;                          // BusinessException (ajusta si tu translator usa otra)

namespace Data.Tests.Security
{
    [TestClass]
    public class PersonCommandDataIntegrationTests
    {
        private static ServiceProvider _root = default!;
        private IServiceScope _scope = default!;
        private AplicationDbContext _ctx = default!;
        private PersonCommandData _sut = default!;
        private readonly List<int> _createdPersonIds = new();

        // ------------------- FIXTURE GLOBAL -------------------

        [ClassInitialize]
        public static void ClassInit(TestContext _)
        {
            // Cargar el mismo appsettings.json que usas en Web (enlázalo al proyecto de tests)
            var cfg = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .AddEnvironmentVariables()
                .Build();

            // Usa lo mismo que en Program.cs
            const string engine = "PgAdmin";
            const string connectionName = "PgAdmin";

            var services = new ServiceCollection();

            services.AddLogging(b =>
            {
                b.ClearProviders();
                b.AddConsole();
                b.SetMinimumLevel(LogLevel.Information);
            });

            // Interceptor no-op (ctor con IServiceProvider)
            services.AddScoped<LogginDbCommandsInterceptor, NoopDbCommandsInterceptor>();

            // Registrar DbContext vía tu factoría
            var configurator = DbEngineFactory.GetConfigurator(engine);
            configurator.Configure(services, cfg, connectionName);

            _root = services.BuildServiceProvider(validateScopes: true);

            // NO migramos aquí (las migraciones ya corren solas en tu entorno)
            // Seed de tablas de referencia UNA vez (si hace falta)
            using var scope = _root.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<AplicationDbContext>();
            SeedLookupsOnce(db).GetAwaiter().GetResult();
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            if (_root is IDisposable d) d.Dispose();
        }

        // ------------------- POR PRUEBA -------------------

        [TestInitialize]
        public void TestInit()
        {
            _scope = _root.CreateScope();
            _ctx = _scope.ServiceProvider.GetRequiredService<AplicationDbContext>();
            _sut = new PersonCommandData(
                _ctx,
                _scope.ServiceProvider.GetRequiredService<ILogger<PersonCommandData>>()
            );
        }

        [TestCleanup]
        public async Task TestCleanup()
        {
            // Limpieza selectiva de lo creado en el test
            if (_createdPersonIds.Count > 0)
            {
                foreach (var id in _createdPersonIds)
                {
                    var p = await _ctx.Set<Person>().FindAsync(id);
                    if (p != null) _ctx.Remove(p);
                }
                await _ctx.SaveChangesAsync();
            }
            _scope?.Dispose();
        }

        // ------------------- HELPERS -------------------

        private static async Task SeedLookupsOnce(AplicationDbContext ctx)
        {
            if (await ctx.Set<Rh>().FindAsync(1) is null)
                ctx.Add(new Rh { Id = 1, Name = "O+" });

            if (await ctx.Set<Eps>().FindAsync(1) is null)
                ctx.Add(new Eps { Id = 1, Name = "Sura" });

            if (await ctx.Set<Munisipality>().FindAsync(1) is null)
                ctx.Add(new Munisipality { Id = 1, Name = "Medellín" });

            if (await ctx.Set<MaterialStatus>().FindAsync(1) is null)
                ctx.Add(new MaterialStatus { Id = 1, Name = "Soltero" });

            // Si Person exige DocumentTypeId (FK), descomenta y ajusta:
            // if (await ctx.Set<DocumentType>().FindAsync(1) is null)
            //     ctx.Add(new DocumentType { Id = 1, Name = "CC" });

            await ctx.SaveChangesAsync();
        }

        private static Person NewPerson(
            int rhId = 1,
            int epsId = 1,
            int municipalityId = 1,
            int materialStatusId = 1,
            string address = "Calle 123",
            DateTime? birth = null,
            int stratum = 3)
        {
            var person = new Person
            {
                // ⚠️ Ajusta los nombres a tu entidad real:
                // Si tu propiedad es "FisrtName" (typo) usa esa.
                FisrtName = "Ada",
                LastName = "Lovelace",
                SecondName = "Prueba",
                SecondLastName = "segundo apellido prueba",
                Age = 30,
                Gender = GenderEmun.Masculino,
                Identification = 1002003004, // long/int según tu modelo
                Phone = 3234234,
                DocumentTypeId = 1,           // si es obligatorio
                Status = 1
            };

            person.DataBasic = new DataBasic
            {
                RhId = rhId,
                EpsId = epsId,
                MunisipalityId = municipalityId,
                MaterialStatusId = materialStatusId,
                Adress = address,
                BrithDate = birth ?? new DateTime(1990, 1, 1),
                StratumStatus = stratum,
                Person = person
            };

            return person;
        }

        // ------------------- TESTS -------------------

        [TestMethod]
        public async Task InsertComplete_Inserta_Guarda_Devuelve_AsNoTracking_Con_DataBasic_Y_FKs()
        {
            // Arrange
            var person = NewPerson(
                rhId: 1, epsId: 1, municipalityId: 1, materialStatusId: 1,
                address: "Cra 45 #67-89", birth: new DateTime(1988, 5, 20), stratum: 4
            );

            // Act
            var result = await _sut.InsertComplete(person);
            _createdPersonIds.Add(result.Id); // para limpiar al final

            // Assert
            Assert.IsTrue(result.Id > 0);
            Assert.IsNotNull(result.DataBasic);
            Assert.AreEqual("Cra 45 #67-89", result.DataBasic!.Adress);
            Assert.AreEqual(new DateTime(1988, 5, 20), result.DataBasic!.BrithDate);
            Assert.AreEqual(4, result.DataBasic!.StratumStatus);
            Assert.AreEqual(1, result.DataBasic!.RhId);
            Assert.AreEqual(1, result.DataBasic!.EpsId);
            Assert.AreEqual(1, result.DataBasic!.MunisipalityId);
            Assert.AreEqual(1, result.DataBasic!.MaterialStatusId);

            // Debe venir sin tracking (consulta AsNoTracking en el método)
            Assert.AreEqual(EntityState.Detached, _ctx.Entry(result).State);

            // Verificación en DB
            var fromDb = await _ctx.Set<Person>()
                .Include(p => p.DataBasic)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == result.Id);

            Assert.IsNotNull(fromDb);
            Assert.IsNotNull(fromDb!.DataBasic);
            Assert.AreEqual(result.Id, fromDb.DataBasic!.PersonId);
        }

        [TestMethod]
        public async Task UpdateCompleteAsync_Persiste_Cambios_En_Entidad_Trackeada()
        {
            // Arrange: seed + attach
            var seed = NewPerson(address: "Calle 10", stratum: 2);
            _ctx.Set<Person>().Add(seed);
            await _ctx.SaveChangesAsync();
            _createdPersonIds.Add(seed.Id);

            var tracked = await _ctx.Set<Person>()
                .Include(p => p.DataBasic)
                .FirstAsync(p => p.Id == seed.Id);

            tracked.DataBasic!.Adress = "Avenida 80";
            tracked.DataBasic!.StratumStatus = 5;

            // Act
            var result = await _sut.UpdateCompleteAsync(tracked);

            // Assert
            Assert.AreEqual(seed.Id, result.Id);
            Assert.IsNotNull(result.DataBasic);
            Assert.AreEqual("Avenida 80", result.DataBasic!.Adress);
            Assert.AreEqual(5, result.DataBasic!.StratumStatus);
            Assert.AreEqual(EntityState.Detached, _ctx.Entry(result).State);

            var check = await _ctx.Set<Person>().AsNoTracking()
                .Include(p => p.DataBasic)
                .FirstAsync(p => p.Id == seed.Id);

            Assert.AreEqual("Avenida 80", check.DataBasic!.Adress);
            Assert.AreEqual(5, check.DataBasic!.StratumStatus);
        }

        [TestMethod]
        public async Task QueryByIdTrackedAsync_Retorna_Trackeado_Con_DataBasic()
        {
            // Arrange: usar SIEMPRE NewPerson(...) que ya rellena secondName
            var seed = NewPerson(address: "Diagonal 50");
            _ctx.Set<Person>().Add(seed);
            await _ctx.SaveChangesAsync();
            _createdPersonIds.Add(seed.Id);

            // Act
            var tracked = await _sut.QueryByIdTrackedAsync(seed.Id);

            // Assert
            Assert.IsNotNull(tracked);
            Assert.IsNotNull(tracked!.DataBasic);
            Assert.AreEqual("Diagonal 50", tracked.DataBasic!.Adress);
            Assert.AreEqual(EntityState.Unchanged, _ctx.Entry(tracked).State);
        }


        [TestMethod]
        public async Task InsertComplete_Si_DbUpdateException_Se_Traduce_A_ExcepcionDeNegocio()
        {
            // Contexto que fuerza DbUpdateException en SaveChanges (no toca migraciones)
            using var failingScope = _root.CreateScope();
            var opts = failingScope.ServiceProvider.GetRequiredService<DbContextOptions<AplicationDbContext>>();
            using var failingCtx = new FailingSaveContext(opts);

            var failingSut = new PersonCommandData(
                failingCtx,
                failingScope.ServiceProvider.GetRequiredService<ILogger<PersonCommandData>>()
            );

            try
            {
                await failingSut.InsertComplete(NewPerson());
                Assert.Fail("Debió lanzar excepción traducida.");
            }
            catch (ExternalServiceException ex) // el tipo real según tu log
            {
                // Verifica que el mensaje general sea el esperado
                StringAssert.Contains(ex.Message, "Error en el servicio externo");
                StringAssert.Contains(ex.Message, "Database");
                StringAssert.Contains(ex.Message, "Error al persistir los cambios");
            }
        }

        // ------------------- SOPORTE -------------------

        // Interceptor no-op para resolver DI (tu interceptor real requiere IServiceProvider)
        private class NoopDbCommandsInterceptor : LogginDbCommandsInterceptor
        {
            public NoopDbCommandsInterceptor(IServiceProvider sp) : base(sp) { }
        }

        // Contexto que falla al guardar para ejercitar la traducción de excepciones
        private class FailingSaveContext : AplicationDbContext
        {
            public FailingSaveContext(DbContextOptions<AplicationDbContext> options) : base(options) { }
            public override int SaveChanges() => throw new DbUpdateException("forced failure (sync)");
            public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
                => throw new DbUpdateException("forced failure (async)");
        }
    }
}

