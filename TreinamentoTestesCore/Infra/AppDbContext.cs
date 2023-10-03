using Microsoft.EntityFrameworkCore;
using TreinamentoTestesCore.Domain.Entities;

namespace TreinamentoTestesCore.Infra
{
    public class AppDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderRequest> OrderRequests { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=database.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure as relações e restrições das entidades aqui, se necessário.
        }
    }
}
