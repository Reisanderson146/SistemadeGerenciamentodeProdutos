using Microsoft.EntityFrameworkCore;
using SistemadeGerenciamentodeProdutos.Domain.Entities;
using SistemadeGerenciamentodeProdutos.Domain.Repositories;
using SistemadeGerenciamentodeProdutos.Infrastructure.Persistence;
using System;

namespace SistemadeGerenciamentodeProdutos.Infrastructure.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Produto?> ObterPorIdAsync(int id)
        {
            return await _context.Produtos
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Produto>> ObterTodosAsync()
        {
            return await _context.Produtos
                .AsNoTracking()
                .OrderBy(p => p.Nome)
                .ToListAsync();
        }

        public async Task AdicionarAsync(Produto produto)
        {
            await _context.Produtos.AddAsync(produto);
        }

        public void Atualizar(Produto produto)
        {
            _context.Produtos.Update(produto);
        }

        public void Remover(Produto produto)
        {
            _context.Produtos.Remove(produto);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
