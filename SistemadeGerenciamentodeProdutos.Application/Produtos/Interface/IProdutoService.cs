using SistemadeGerenciamentodeProdutos.Application.Produtos.Dto;

namespace SistemadeGerenciamentodeProdutos.Application.Produtos.Interfaces
{
    public interface IProdutoService
    {
        Task<List<ProdutoResponse>> ObterTodosAsync();
        Task<ProdutoResponse?> ObterPorIdAsync(int id);
        Task<ProdutoResponse> CriarAsync(CriarProdutoRequest request);
        Task<bool> AtualizarAsync(int id, AtualizarProdutoRequest request);
        Task<bool> RemoverAsync(int id);
    }
}
