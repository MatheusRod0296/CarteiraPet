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
        private readonly IIdentityUserService _identityUserService;
        

        public ProfileService(IProfileRepository profileRepository,
            IIdentityUserService identityUserService)
        {
            _profileRepository = profileRepository;
            _identityUserService = identityUserService;
        }

        public async Task<bool> Insert(ProfileModel profileFromView)
        {
            try
            {
                await _identityUserService.AddFriendlyName(profileFromView.Name);
                await _identityUserService.AddFrindlyNameClaim(profileFromView.Name);
                
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