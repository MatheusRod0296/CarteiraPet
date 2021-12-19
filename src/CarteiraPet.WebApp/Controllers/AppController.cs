using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
namespace CarteiraPet.WebApp.Controllers
{
    public class AppController : Controller
    {
        protected Guid GetUserId()
        {
            return new Guid(HttpContext.User.Identity.GetUserId());
        }
    }
}
