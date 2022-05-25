using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarteiraPet.Domain.Interfaces.Repositories;
using CarteiraPet.Domain.Interfaces.Services;
using CarteiraPet.Domain.Interfaces.UnitOfWork;
using CarteiraPet.Domain.Models;

namespace CarteiraPet.Service
{
    public class PetService : IPetService
    {
        private readonly IPetRepository _petRepository;
        private readonly IUnitOfWork _unitOfWork;
        public PetService(IPetRepository petRepository, IUnitOfWork unitOfWork)
        {
            _petRepository = petRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Create(PetModel pet)
        {
            await _petRepository.Insert(pet);
            return await _unitOfWork.Commit();
        }

        public async Task<List<PetModel>> Get(Guid ProfileId)
        {
            return await _petRepository.Get(ProfileId);
        }
        public async Task<PetModel> GetById(Guid PetId)
        {
            return await _petRepository.GetById(PetId);
        }
    }
}
