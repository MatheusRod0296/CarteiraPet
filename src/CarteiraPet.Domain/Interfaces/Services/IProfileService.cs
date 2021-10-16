using System.Threading.Tasks;
using CarteiraPet.Domain.Models;

namespace CarteiraPet.Domain.Interfaces.Services
{
    public interface IProfileService
    {
        Task<bool> Insert(ProfileModel profile);
        Task<ProfileModel> Get(string email);
    }
}