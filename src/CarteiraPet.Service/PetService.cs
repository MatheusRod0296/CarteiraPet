using System.Threading.Tasks;
using CarteiraPet.Domain.Interfaces.Repositories;
using CarteiraPet.Domain.Interfaces.Services;
using CarteiraPet.Domain.Models;

namespace CarteiraPet.Service
{
    public class PetService : IPetService
    {
        private readonly IPetRepository _petRepository;
        public PetService(IPetRepository petRepository) {
            _petRepository = petRepository;
        }
        public async Task<bool> Create(PetModel pet)
        {
            return await _petRepository.Insert(pet);
        }
    }
}
