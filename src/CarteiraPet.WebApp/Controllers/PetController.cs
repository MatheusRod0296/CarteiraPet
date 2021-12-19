using System.Threading.Tasks;
using CarteiraPet.Commom.extensions;
using CarteiraPet.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace CarteiraPet.WebApp.Controllers
{
    [Authorize]
    public class PetController: Controller
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
        
        public async Task<IActionResult> CreatePet(PetCreateViewModel petWM)
        {
            Log.Logger.Logtrace(new TraceCustomLog("1234", true, "Pet Insert"));
            return View("Index");
        }
        
    }
}