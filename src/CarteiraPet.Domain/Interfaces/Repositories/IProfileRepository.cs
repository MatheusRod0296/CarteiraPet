using System.Threading.Tasks;
using CarteiraPet.Domain.Models;

namespace CarteiraPet.Domain.Interfaces.Repositories
{
    public interface IProfileRepository
    {
        Task Insert(ProfileModel profile);
        Task Update(ProfileModel profile);
        Task<ProfileModel> GetByEmail(string email);
        Task<bool> ExistProfile(string email);
    }
}
