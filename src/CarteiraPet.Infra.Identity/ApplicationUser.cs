using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CarteiraPet.Infra
{
    public class ApplicationUser: IdentityUser
    {
        public string FriendlyName { get; set; }

    }
}