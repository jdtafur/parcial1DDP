using Microsoft.EntityFrameworkCore;

namespace Inventario.Infrastructure.Data.Base
{
    public interface IDbContext
    {
        DbSet<T> Set<T>() where T : class;
        int SaveChanges();
    }
}