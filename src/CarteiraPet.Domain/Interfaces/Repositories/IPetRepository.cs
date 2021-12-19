using System.Threading.Tasks;
using CarteiraPet.Domain.Models;
namespace CarteiraPet.Domain.Interfaces.Repositories
{
    public interface IPetRepository
    {
        Task<bool> Insert(PetModel pet);
    }
}
