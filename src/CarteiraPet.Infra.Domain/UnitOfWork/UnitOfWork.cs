using System.Threading.Tasks;
using CarteiraPet.Domain.Interfaces.UnitOfWork;
using CarteiraPet.Infra.Domain.Data;

namespace CarteiraPet.Infra.Domain.UnitOfWork
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly CarteiraPetContext _context;
        
        public UnitOfWork(CarteiraPetContext context) {
            _context = context;
        }

        public async Task<bool> Commit()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
