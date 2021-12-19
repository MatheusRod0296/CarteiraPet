using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CarteiraPet.Commom.extensions;
using CarteiraPet.Domain.Interfaces.Services;
using CarteiraPet.Domain.Models;
using CarteiraPet.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace CarteiraPet.WebApp.Controllers
{
    [Authorize]
    public class PetController: AppController
    {
        public async Task<IActionResult> Index()
        {
            Log.Logger.Logtrace(new TraceCustomLog("1234", true, "Pet Index"));
            return View();
        }
        
        public async Task<IActionResult> CreateForm()
        {
            Log.Logger.Logtrace(new TraceCustomLog("1234", true, "Pet Insert"));
            return View();
        }
        
        public async Task<IActionResult> CreatePet([FromServices] IPetService petService, PetCreateViewModel petWM)
        {
            Log.Logger.Logtrace(new TraceCustomLog("1234", true, "Pet Insert"));

            var pet = new PetModel(
                petWM.Name,
                petWM.BirthDate,
                petWM.Sex,
                ConvertImageTo64Base(petWM.Photo),
                GetUserId()
            );

            await petService.Create(pet);
            
            return View("Index");
        }

        private string ConvertImageTo64Base(IFormFile file)
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

            return base64;
        }
        
    }
}
