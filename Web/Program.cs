using DotNetEnv;
using Entity.Context.Main;
using Entity.Dtos.Services;
using Utilities.AlmacenadorArchivos.implementes;
using Utilities.AlmacenadorArchivos.Interface;
using Utilities.Helpers;
using Utilities.Helpers.interfaces;
using Utilities.Helpers.messageEmail;
using Utilities.SignalR.Implements;
using Web.Extendes;
using Web.Middlewares;

// carga archivo ENV
Env.Load();

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddSignalR();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMapperApp();


// Configuracion de la base de datos
builder.Services.AddDb("PgAdmin", builder.Configuration);

//builder.Services.AddDb("PgAdminLog", builder.Configuration);


// Inyeccion de dependencias de los controladores
builder.Services.AddInject();
builder.Services.AddJwtConfig(builder.Configuration);
builder.Services.AddViewAuthApi();

//Agrega las validaciones genericas
builder.Services.AddHelpersValidation();
builder.Services.AddCustomCors(builder.Configuration);


// azure (AlmacenadorArchivos) local (AlmacenadorLocal) esto para el almacenamiento de las imagenes
builder.Services.AddTransient<IAlmacenadorArchivos, AlmacenadorArchivos>();
builder.Services.AddHttpContextAccessor();
//builder.Services.AddTransient<IAlmacenadorArchivos, AlmacenadorLocal>();

// CACHE
builder.Services.AddOutputCache((options) =>
{
    // se puede configurar para minutos, horas dias ..
    options.DefaultExpirationTimeSpan = TimeSpan.FromSeconds(10);
});


// Registro de inyeccion de la configuraciones de email
builder.Services.Configure<SmtpOptions>(
    builder.Configuration.GetSection("SmtpOptions"));

// Inyeccion de dependencias del servicio de email
builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.AddSingleton<IEmailTemplateRenderer, RazorLightEmailTemplateRenderer>(); // Template

var app = builder.Build();

await app.MigrateDatabaseAsync<AplicationDbContext>();

// descripcion de errores
app.UseMiddleware<ProblemDetailsMiddleware>();



app.UseSwagger();
app.UseSwaggerUI(c =>
{
    // Endpoint del JSON de Swagger
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mi API V1");

    // Esto colapsa todos los endpoints
    c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
});

// para servir achivos estaticos
app.UseStaticFiles();

// Middleware del cache
app.UseOutputCache();

app.UseHttpsRedirection();
app.UseCors();

app.MapHub<NotificationHub>("/hubs/notifications");

app.UseAuthorization();

app.MapControllers();

app.Run();
