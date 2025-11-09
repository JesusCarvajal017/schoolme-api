using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Utilities.AlmacenadorArchivos.Interface;

namespace Utilities.AlmacenadorArchivos.implementes
{
    public class AlmacenadorArchivos : IAlmacenadorArchivos
    {

        private string connectionString;
        public AlmacenadorArchivos(IConfiguration configuration)
        {
            //connectionString = configuration.GetConnectionString("AzureStorageKey")!;
            // lectura de variable de ambiente
            connectionString = Environment.GetEnvironmentVariable("AZURE_STORAGE_CONNECTION");
        }
        public async Task<string> Almacenar(string contenedor, IFormFile archivo)
        {
            var cliente = new BlobContainerClient(connectionString, contenedor);

            await cliente.CreateIfNotExistsAsync();
            cliente.SetAccessPolicy(PublicAccessType.Blob);

            var extension = Path.GetExtension(archivo.Name);
            var NombreArchivo = $"{Guid.NewGuid()}{extension}";
            var blob = cliente.GetBlobClient(NombreArchivo);

            var blobHttpHeaders = new BlobHttpHeaders();
            blobHttpHeaders.ContentType = archivo.ContentType;

            await blob.UploadAsync(archivo.OpenReadStream(), blobHttpHeaders);
            return blob.Uri.ToString();

        }

        public async Task Borrar(string? ruta, string contenedor)
        {
            if (string.IsNullOrWhiteSpace(ruta))
            {
                return ;
            }


            var cliente = new BlobContainerClient(this.connectionString, contenedor);
            await cliente.CreateIfNotExistsAsync();
            var nombreArchivo = Path.GetFileName(ruta);
            var blob = cliente.GetBlobClient(nombreArchivo);

            await blob.DeleteIfExistsAsync();
        }
    }
}
