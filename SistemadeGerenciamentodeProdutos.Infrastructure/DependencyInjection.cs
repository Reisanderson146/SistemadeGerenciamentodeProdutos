using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemadeGerenciamentodeProdutos.Domain.Repositories;
using SistemadeGerenciamentodeProdutos.Infrastructure.Persistence;
using SistemadeGerenciamentodeProdutos.Infrastructure.Repositories;

namespace SistemadeGerenciamentodeProdutos.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IProdutoRepository, ProdutoRepository>();

            return services;
        }
    }
}
