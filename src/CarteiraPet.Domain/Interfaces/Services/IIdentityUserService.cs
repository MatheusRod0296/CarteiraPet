using System.Threading.Tasks;

namespace CarteiraPet.Domain.Interfaces.Services
{
    public interface IIdentityUserService
    {
        Task AddFriendlyName(string friendlyName);
        Task AddFrindlyNameClaim(string value);
    }
}