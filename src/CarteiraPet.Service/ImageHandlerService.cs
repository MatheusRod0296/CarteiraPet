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
            if (file.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    base64 = Convert.ToBase64String(fileBytes);
                }
            }

            return Task.FromResult(base64);
        }
    }
}
