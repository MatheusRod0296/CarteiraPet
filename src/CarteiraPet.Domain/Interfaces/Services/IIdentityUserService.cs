using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CarteiraPet.Domain.Interfaces.Services
{
    public interface IIdentityUserService
    {
        Task AddFriendlyName(string friendlyName);

        Task AddFriendlyName(IdentityUser identityUser, string friendlyName);

        Task AddFrindlyNameClaim(string value);
        Task AddFrindlyNameClaim(IdentityUser identityUser, string value);
    }
}
