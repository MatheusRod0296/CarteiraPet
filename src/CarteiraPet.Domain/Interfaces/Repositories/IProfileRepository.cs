using System.Threading.Tasks;
using CarteiraPet.Domain.Models;

namespace CarteiraPet.Domain.Interfaces.Repositories
{
    public interface IProfileRepository
    {
        Task<bool> Insert(ProfileModel profile);

        Task<bool> ExistProfile(string email);
    }
}