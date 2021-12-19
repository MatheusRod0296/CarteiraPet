using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CarteiraPet.Domain.Interfaces.Services
{
    public interface IImageHandlerService
    {
        Task<string> ConvertImageTo64Base(IFormFile file);
    }
}
