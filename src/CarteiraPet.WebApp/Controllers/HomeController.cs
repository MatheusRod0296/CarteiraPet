using System.Diagnostics;
using CarteiraPet.Commom.extensions;
using Microsoft.AspNetCore.Mvc;
using CarteiraPet.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Serilog;

namespace CarteiraPet.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
           
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