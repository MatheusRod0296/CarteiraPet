using System.Threading.Tasks;
namespace CarteiraPet.Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
