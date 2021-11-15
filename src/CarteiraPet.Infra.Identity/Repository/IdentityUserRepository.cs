using System.Linq;
using System.Threading.Tasks;
using CarteiraPet.Domain.Interfaces.Repositories;
using CarteiraPet.Infra.Identity.Data;


namespace CarteiraPet.Infra
{
    public class IdentityUserRepository : IIdentityUserRepository
    {
        private readonly ApplicationDbContext _context;
        
        public IdentityUserRepository( ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<string> GetFriendlynname(string userId)
        {
          return await Task.FromResult(_context.Users.FirstOrDefault(x => x.Id == userId)?.FriendlyName);
        }
    }
}