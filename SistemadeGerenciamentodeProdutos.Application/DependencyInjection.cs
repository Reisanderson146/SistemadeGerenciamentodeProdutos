using Microsoft.Extensions.DependencyInjection;
using SistemadeGerenciamentodeProdutos.Application.Produtos.Interfaces;
using SistemadeGerenciamentodeProdutos.Application.Produtos.Services;

namespace SistemadeGerenciamentodeProdutos.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IProdutoService, ProdutoService>();

            return services;
        }
    }
}
