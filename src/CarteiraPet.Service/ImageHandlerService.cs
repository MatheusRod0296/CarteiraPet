using System;
using System.IO;
using System.Threading.Tasks;
using CarteiraPet.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;

namespace CarteiraPet.Service
{
    public class ImageHandlerService : IImageHandlerService
    {
        public Task<string> ConvertImageTo64Base(IFormFile file)
        {
            string base64 = String.Empty;
            if ( file.Length > 0 )
            {
                using ( var ms = new MemoryStream() )
                {
                    file.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    base64 = Convert.ToBase64String(fileBytes);
                }
            }

            return Task.FromResult("data:image/png;base64," + base64);
        }
        
        public Task<IFormFile> Convert64BaseToImage(string photo)
        {
            byte[] bytes = Convert.FromBase64String(photo);
            MemoryStream stream = new MemoryStream(bytes);
        
            IFormFile file = new FormFile(stream, 0, bytes.Length, "Name", "name");

            return Task.FromResult(file);
        }
    }
}
