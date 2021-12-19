using System;
using System.Threading.Tasks;
using CarteiraPet.Domain.Models;


namespace CarteiraPet.Domain.Interfaces.Services
{
    public interface IProfileService
    {
        Task<bool> Insert(string email, Guid userId);
        Task<bool> Update(ProfileModel profileFromView);
        Task<ProfileModel> Get(string email);
    }
}
