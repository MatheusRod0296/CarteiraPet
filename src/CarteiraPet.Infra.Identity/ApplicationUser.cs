using Microsoft.AspNetCore.Identity;

namespace CarteiraPet.Infra
{
    public class ApplicationUser: IdentityUser
    {
        public string FriendlyName { get; set; }

    }
}
