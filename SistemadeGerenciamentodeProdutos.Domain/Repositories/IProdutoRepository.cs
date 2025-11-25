using SistemadeGerenciamentodeProdutos.Domain.Entities;

namespace SistemadeGerenciamentodeProdutos.Domain.Repositories
{
    public interface IProdutoRepository
    {
        Task<Produto?> ObterPorIdAsync(int id);
        Task<List<Produto>> ObterTodosAsync();
        Task AdicionarAsync(Produto produto);
        void Atualizar(Produto produto);
        void Remover(Produto produto);
        Task<bool> SaveChangesAsync();
    }
}