using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Utilities.AlmacenadorArchivos.Interface;

namespace Utilities.AlmacenadorArchivos.implementes
{
    public class AlmacenadorLocal : IAlmacenadorArchivos
    {
        private readonly IWebHostEnvironment env;
        private readonly IHttpContextAccessor httpContextAccesor;

        public AlmacenadorLocal(IWebHostEnvironment env, IHttpContextAccessor httpContextAccesor)
        {
            this.env = env;
            this.httpContextAccesor = httpContextAccesor;
        }

        public async Task<string> Almacenar(string contenedor, IFormFile archivo)
        {
            try
            {
                if (archivo is null || archivo.Length == 0)
                    throw new ArgumentException("El archivo está vacío o es nulo.");

                var ext = Path.GetExtension(archivo.FileName);
                var nombreArchivo = $"{Guid.NewGuid():N}{ext}";
                var webRoot = env.WebRootPath ?? Path.Combine(env.ContentRootPath, "wwwroot");
                var carpeta = Path.Combine(webRoot, contenedor);
                Directory.CreateDirectory(carpeta);
                var ruta = Path.Combine(carpeta, nombreArchivo);

                await using (var fs = new FileStream(ruta, FileMode.CreateNew, FileAccess.Write))
                {
                    await archivo.CopyToAsync(fs);
                }

                // Solo ruta relativa
                return $"/{contenedor}/{nombreArchivo}";
            }
            catch (Exception ex)
            {
                // Puedes registrar el error aquí
                Console.WriteLine($"[ERROR Almacenar] {ex.Message}\n{ex.StackTrace}");

                // o usar un logger si lo tienes inyectado (ILogger<AlmacenadorLocal>)
                // _logger.LogError(ex, "Error al almacenar archivo en {Contenedor}", contenedor);

                // Luego, relanzas la excepción para que el controlador sepa que falló
                throw new InvalidOperationException($"Error al guardar el archivo: {ex.Message}", ex);
            }
        }

        public Task Borrar(string? ruta, string contenedor)
        {
            if (string.IsNullOrWhiteSpace(ruta))
            {
                return Task.CompletedTask;
            }

            var nombreArchivo = Path.GetFileName(ruta);
            var directorioArchivo = Path.Combine(env.WebRootPath, contenedor, nombreArchivo);

            if (File.Exists(directorioArchivo))
            {
                File.Delete(directorioArchivo);
            }

            return Task.CompletedTask;
        }
    }
}
