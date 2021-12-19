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

        public ProfileController(IProfileService service )
        {
            _service = service;
        }
        
        [Authorize]
        public async Task<IActionResult> Form()
        {
            var email = User.Identity.Name;
            var sss = HttpContext.User.Claims;

            var profile = await _service.Get(email);
            
            var profileVm = new ProfileViewModel
            {
                Email = email,
                Name = profile.Name
            };
                
            return View(profileVm);
        }
        
        [Authorize]
        [HttpPost]
        [Route("profile/add")]
        public async Task<IActionResult> Create(ProfileViewModel profileWM)
        {
            var email = User.Identity.Name;
            var profile = new ProfileModel(email, profileWM.Name);

            var result = await _service.Insert(profile);
            return View();
        }
    }
}