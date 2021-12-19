using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CarteiraPet.Commom;
using CarteiraPet.Domain.Interfaces.Services;
using CarteiraPet.Infra;
using Microsoft.AspNetCore.Identity;

namespace CarteiraPet.Service
{
    public class IdentityUserService : IIdentityUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public IdentityUserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task AddFriendlyName(IdentityUser identityUser, string friendlyName)
        {
            var appUser = identityUser as ApplicationUser;
            appUser.FriendlyName = friendlyName;

            await _userManager.UpdateAsync(appUser);
        }

        public async Task AddFriendlyName(string friendlyName)
        {
            var appUser = await _userManager.GetUserAsync(HttpContextHelper._httpContext?.User);
            await AddFriendlyName(appUser, friendlyName);
        }

        public async Task AddFrindlyNameClaim(IdentityUser identityUser, string value)
        {
            var appUser = identityUser as ApplicationUser;
            var newClaim = new Claim("friendlyName", value);
            var claims = await _userManager.GetClaimsAsync(appUser);
            var claim = claims.FirstOrDefault(c => c.Type == "friendlyName");
            
            if(claim is null)
                await _userManager.AddClaimAsync(appUser, newClaim);
            else
                await _userManager.ReplaceClaimAsync(appUser, claim, newClaim);
        }

        public async Task AddFrindlyNameClaim(string value)
        {
            var appUser = await _userManager.GetUserAsync(HttpContextHelper._httpContext?.User);
            await AddFrindlyNameClaim(appUser, value);
        }

    }
}
