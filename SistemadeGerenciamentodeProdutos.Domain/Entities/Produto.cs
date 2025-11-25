using SistemadeGerenciamentodeProdutos.Domain.Entities;


namespace SistemadeGerenciamentodeProdutos.Domain.Entities
{
    public class Produto
    {
        private Produto() { }

        public Produto(string nome, string? descricao, decimal precoUnitario, int quantidadeInicial)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome é obrigatório.", nameof(nome));

            if (quantidadeInicial <= 0)
                throw new ArgumentException("Quantidade inicial deve ser maior que zero.", nameof(quantidadeInicial));

            if (precoUnitario < 0)
                throw new ArgumentException("Preço unitário não pode ser negativo.", nameof(precoUnitario));

            Nome = nome;
            Descricao = descricao;
            PrecoUnitario = precoUnitario;
            QuantidadeEstoque = quantidadeInicial;
            Ativo = true;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; } = string.Empty;
        public string? Descricao { get; private set; }
        public decimal PrecoUnitario { get; private set; }
        public int QuantidadeEstoque { get; private set; }
        public bool Ativo { get; private set; }

        public void Atualizar(string nome, string? descricao, decimal precoUnitario)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome é obrigatório.", nameof(nome));

            if (precoUnitario < 0)
                throw new ArgumentException("Preço unitário não pode ser negativo.", nameof(precoUnitario));

            Nome = nome;
            Descricao = descricao;
            PrecoUnitario = precoUnitario;
        }

        public void DefinirQuantidadeEstoque(int quantidade)
        {
            if (quantidade < 0)
                throw new InvalidOperationException("Quantidade em estoque não pode ser negativa.");

            QuantidadeEstoque = quantidade;
        }

        public void DefinirAtivo(bool ativo) => Ativo = ativo;
    }
}