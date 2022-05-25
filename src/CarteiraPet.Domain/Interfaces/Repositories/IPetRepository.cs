using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarteiraPet.Domain.Models;
namespace CarteiraPet.Domain.Interfaces.Repositories
{
    public interface IPetRepository
    {
        Task Insert(PetModel pet);
        Task<List<PetModel>> Get(Guid profileId);
        Task<PetModel> GetById(Guid petId);
    }
}
