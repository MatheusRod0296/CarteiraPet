using Microsoft.AspNetCore.Identity;

namespace CarteiraPetWebApp.Identity
{
    public class AppRole : IdentityRole
    {
        public AppRole() : base() { }
        public AppRole(string name) : base(name) { }
    }
}