using Microsoft.EntityFrameworkCore;
using SistemadeGerenciamentodeProdutos.Domain.Entities;

namespace SistemadeGerenciamentodeProdutos.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Produto> Produtos => Set<Produto>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>(entity =>
            {
                entity.ToTable("Produtos");
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Nome).IsRequired().HasMaxLength(200);
                entity.Property(p => p.PrecoUnitario).HasColumnType("decimal(18,2)");
                entity.Property(p => p.QuantidadeEstoque).IsRequired();
                entity.Property(p => p.Ativo).IsRequired().HasDefaultValue(true);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}