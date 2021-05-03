using Inventario.Core.Domain.Contracts;

namespace Inventario.Infrastructure.Data.Base
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly IDbContext _context;
        public UnitOfWork(IDbContext context) => _context = context;

        public void Commit()
        {
            _context.SaveChanges();
        }

        
    }
}