using System.Threading.Tasks;
using CarteiraPet.Domain.Interfaces.Repositories;
using CarteiraPet.Domain.Models;
using CarteiraPet.Infra.Domain.Data;
using Microsoft.EntityFrameworkCore;

namespace CarteiraPet.Infra.Domain.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly CarteiraPetContext _context;

        public ProfileRepository(CarteiraPetContext context)
        {
            _context = context;
        }

        public Task Insert(ProfileModel profile)
        {
            _context.Profile.Add(profile);
            return Task.CompletedTask;
        }

        public Task Update(ProfileModel profile)
        {
            _context.Profile.Update(profile);
            return Task.CompletedTask;
        }

        public async Task<ProfileModel> GetByEmail(string email) =>
            await _context.Profile.FirstOrDefaultAsync(x => x.Email == email);

        public async Task<bool> ExistProfile(string email)
        {
            var profile = await _context.Profile.FirstOrDefaultAsync(p => p.Email == email);
            return profile != null;
        }
    }
}
