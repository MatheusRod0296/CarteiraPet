using System.Diagnostics;
using CarteiraPet.Commom.extensions;
using Microsoft.AspNetCore.Mvc;
using CarteiraPet.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Serilog;


namespace CarteiraPet.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Log.Logger.Important("PrivacyController");
            return View();
        }
        
        [Authorize]
        public IActionResult Privacy()
        {
            Log.Logger.Logtrace(new TraceCustomLog("1234", true, "PrivacyMethod"));
            
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}