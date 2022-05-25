using System;
using System.Threading.Tasks;
using CarteiraPet.Commom.extensions;
using CarteiraPet.Domain.Interfaces.Services;
using CarteiraPet.Domain.Models;
using CarteiraPet.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace CarteiraPet.WebApp.Controllers
{
    [Authorize]
    public class PetController: AppController
    {
        public async Task<IActionResult> Index([FromServices] IPetService petService)
        {
            Log.Logger.Logtrace(new TraceCustomLog("1234", true, "Pet Index"));
            var pets = await petService.Get(GetUserId());
            
            return View(pets);
        }
        
        public async Task<IActionResult> CreateForm()
        {
            Log.Logger.Logtrace(new TraceCustomLog("1234", true, "Pet Insert"));
            ViewData["maxDate"] = DateTime.Now.ToString("yyyy-MM-dd");
            return View();
        }

        public async Task<IActionResult> CreatePet(
            [FromServices] IPetService petService,
            [FromServices] IImageHandlerService _imageHandlerService,
            PetCreateViewModel petWM)
        {
            Log.Logger.Logtrace(new TraceCustomLog("1234", true, "Pet Insert"));
            if (!ModelState.IsValid)
            {
                return View("CreateForm");
            }
           
            var photo = await _imageHandlerService.ConvertImageTo64Base(petWM.Photo);
            
            var pet = new PetModel(
                petWM.Name,
                petWM.BirthDate.Value,
                petWM.Sex.Value,
                photo,
                GetUserId()
            );

            await petService.Create(pet);
            
            return Redirect("index");
        }

        public async Task<IActionResult> Get([FromServices] IPetService petService, Guid id)
        {
            var pet = await petService.GetById(id);
            return View(pet);
        }
        
        
    }
}
