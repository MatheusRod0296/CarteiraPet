using System;
using System.Threading.Tasks;
using CarteiraPet.Domain.Interfaces.Repositories;
using CarteiraPet.Domain.Interfaces.Services;
using CarteiraPet.Domain.Interfaces.UnitOfWork;
using CarteiraPet.Domain.Models;
using Serilog;

namespace CarteiraPet.Service
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;
        private readonly IIdentityUserService _identityUserService;
        private readonly IUnitOfWork _unitOfWork;
        public ProfileService(IProfileRepository profileRepository,
            IIdentityUserService identityUserService,
            IUnitOfWork unitOfWork)
        {
            _profileRepository = profileRepository;
            _identityUserService = identityUserService;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Insert(string email, Guid userId)
        {
            var result = false;
            try
            {
                var profile = new ProfileModel(email, String.Empty);
                profile.SetId(userId);
                
                if ( _profileRepository.GetByEmail(email).Result is null )
                {
                    await _profileRepository.Insert(profile);
                    return await _unitOfWork.Commit();
                }
            }
            catch (Exception e)
            {
                Log.Logger.Error(e, e.Message);
            }

            return result;
        }
        
        public async Task<bool> Update(ProfileModel profileFromView)
        {
            try
            {
                var profile = await _profileRepository.GetByEmail(profileFromView.Email);

                if (profile is null)
                    return false;

                profile.Update(profileFromView.Name);
                
                await _identityUserService.AddFriendlyName(profile.Name);
                await _identityUserService.AddFrindlyNameClaim(profile.Name);
                
                await _profileRepository.Update(profile);
                return await _unitOfWork.Commit();
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
