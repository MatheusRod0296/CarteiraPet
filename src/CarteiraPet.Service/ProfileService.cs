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

        public async Task<bool> Insert(ProfileModel profile)
        {
            try
            {
                var existProfile = await _profileRepository.ExistProfile(profile.Email);

                if (!existProfile)
                    return await _profileRepository.Insert(profile);

                return false;
            }
            catch (Exception e)
            {
                Log.Logger.Error(e, e.Message);
                return false;
            }
        }
    }
}