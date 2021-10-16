using System;
using System.Threading.Tasks;
using CarteiraPet.Domain.Interfaces.Repositories;
using CarteiraPet.Domain.Interfaces.Services;
using CarteiraPet.Domain.Models;
using Serilog;

namespace CarteiraPet.Service
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;

        public ProfileService(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public async Task<bool> Insert(ProfileModel profileFromView)
        {
            try
            {
                var profile = await _profileRepository.GetByEmail(profileFromView.Email);

                if (profile is null)
                    return await _profileRepository.Insert(profileFromView);

                profile.Update(profileFromView.Name);

                return await _profileRepository.Update(profile);
            }
            catch (Exception e)
            {
                Log.Logger.Error(e, e.Message);
                return false;
            }
        }

        public async Task<ProfileModel> Get(string email) => await _profileRepository.GetByEmail(email);
        
    }
}