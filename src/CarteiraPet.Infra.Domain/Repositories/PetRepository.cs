using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarteiraPet.Domain.Interfaces.Repositories;
using CarteiraPet.Domain.Models;
using CarteiraPet.Infra.Domain.Data;
using Microsoft.EntityFrameworkCore;
namespace CarteiraPet.Infra.Domain.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly CarteiraPetContext _context;

        public PetRepository(CarteiraPetContext context)
        {
            _context = context;
        }
        
        public Task Insert(PetModel pet)
        {
            _context.Pet.Add(pet);
            return Task.CompletedTask;
        }
        public Task<List<PetModel>> Get(Guid profileId)
        {
            return _context.Pet.Where(x => x.ProfileId == profileId).ToListAsync();
        }
    }
}
