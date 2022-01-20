using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarteiraPet.Domain.Models;

namespace CarteiraPet.Domain.Interfaces.Services
{
    public interface IPetService
    {
        Task<bool> Create(PetModel pet);
        Task<List<PetModel>> Get(Guid ProfileId);
    }
}
