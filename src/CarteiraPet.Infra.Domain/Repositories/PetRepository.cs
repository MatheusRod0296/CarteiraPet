using System.Threading.Tasks;
using CarteiraPet.Domain.Interfaces.Repositories;
using CarteiraPet.Domain.Models;
using CarteiraPet.Infra.Domain.Data;
namespace CarteiraPet.Infra.Domain.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly CarteiraPetContext _context;

        public PetRepository(CarteiraPetContext context)
        {
            _context = context;
        }
        
        public async Task<bool> Insert(PetModel pet)
        {
            _context.Pet.Add(pet);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
