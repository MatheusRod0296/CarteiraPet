using System.Threading.Tasks;
using CarteiraPet.Domain.Interfaces.Services;
using CarteiraPet.Domain.Models;
using CarteiraPet.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarteiraPet.WebApp.Controllers
{
    public class ProfileController: Controller
    {
        private readonly IProfileService _service;
        
        public ProfileController(IProfileService service)
        {
            _service = service;
        }
        
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View();
        }
        
        [Authorize]
        [HttpPost]
        [Route("profile/add")]
        public async Task<IActionResult> CreateProfile(ProfileViewModel profileWM)
        {
            var email = User.Identity.Name;
            
            var profile = new ProfileModel
            {
                Name = profileWM.Name,
                Email = email
            };

            var result = await _service.Insert(profile);
            return View();
        }
    }
}