using System.Threading.Tasks;

namespace CarteiraPet.Domain.Interfaces.Repositories
{
    public interface IIdentityUserRepository
    {
        Task<string> GetFriendlynname(string userId);
    }
}