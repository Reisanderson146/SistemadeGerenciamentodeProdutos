using SistemadeGerenciamentodeProdutos.Application.Produtos.Dto;
using SistemadeGerenciamentodeProdutos.Application.Produtos.Interfaces;
using SistemadeGerenciamentodeProdutos.Domain.Entities;
using SistemadeGerenciamentodeProdutos.Domain.Repositories;

namespace SistemadeGerenciamentodeProdutos.Application.Produtos.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<List<ProdutoResponse>> ObterTodosAsync()
        {
            var produtos = await _produtoRepository.ObterTodosAsync();

            return produtos
                .Select(p => new ProdutoResponse(
                    p.Id,
                    p.Nome,
                    p.Descricao,
                    p.PrecoUnitario,
                    p.QuantidadeEstoque,
                    p.Ativo))
                .ToList();
        }

        public async Task<ProdutoResponse?> ObterPorIdAsync(int id)
        {
            var produto = await _produtoRepository.ObterPorIdAsync(id);
            if (produto is null) return null;

            return new ProdutoResponse(
                produto.Id,
                produto.Nome,
                produto.Descricao,
                produto.PrecoUnitario,
                produto.QuantidadeEstoque,
                produto.Ativo);
        }

        public async Task<ProdutoResponse> CriarAsync(CriarProdutoRequest request)
        {
            var produto = new Produto(
                request.Nome,
                request.Descricao,
                request.PrecoUnitario,
                request.QuantidadeInicial);

            await _produtoRepository.AdicionarAsync(produto);
            await _produtoRepository.SaveChangesAsync();

            return new ProdutoResponse(
                produto.Id,
                produto.Nome,
                produto.Descricao,
                produto.PrecoUnitario,
                produto.QuantidadeEstoque,
                produto.Ativo);
        }

        public async Task<bool> AtualizarAsync(int id, AtualizarProdutoRequest request)
        {
            var produto = await _produtoRepository.ObterPorIdAsync(id);
            if (produto is null) return false;

            produto.Atualizar(request.Nome, request.Descricao, request.PrecoUnitario);

            _produtoRepository.Atualizar(produto);
            return await _produtoRepository.SaveChangesAsync();
        }

        public async Task<bool> RemoverAsync(int id)
        {
            var produto = await _produtoRepository.ObterPorIdAsync(id);
            if (produto is null) return false;

            _produtoRepository.Remover(produto);
            return await _produtoRepository.SaveChangesAsync();
        }
    }
}
