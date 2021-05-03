using Inventario.Core.Domain;
using Inventario.Infrastructure.Data.Base;
using Microsoft.EntityFrameworkCore;

namespace Inventario.Infrastructure.Data
{
    public class BancoContext : DbContextBase
    {
        
        public DbSet<Productos> Productos { get; set; }//equivale a Repositorios
        public DbSet<Simples> ProductosSimples { get; set; }
        public DbSet<Compuestos> ProductosCompuestos { get; set; }

        
        public BancoContext(DbContextOptions options) : base((options))
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Productos>().HasKey(c => c.Id);
            modelBuilder.Entity<Movimiento>().HasKey(c => c.Id);
        }
    }
}