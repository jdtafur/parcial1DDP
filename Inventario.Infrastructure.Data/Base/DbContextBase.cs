using Microsoft.EntityFrameworkCore;

namespace Inventario.Infrastructure.Data.Base
{
    public class DbContextBase: DbContext,IDbContext
    {
        public DbContextBase() 
        {
        }
        public DbContextBase(DbContextOptions options) : base(options)
        {

        }
    }
}