using System.Diagnostics;
using CarteiraPet.Commom.extensions;
using CarteiraPet.Domain.Interfaces.Services;
using CarteiraPet.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace CarteiraPet.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProfileService _service;
        
        public HomeController(IProfileService service)
        {
            _service = service;
          
        }

        public IActionResult Index()
        {
            Log.Logger.Important("HomeController");
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}