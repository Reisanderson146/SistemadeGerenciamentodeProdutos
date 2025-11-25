namespace SistemadeGerenciamentodeProdutos.Application.Produtos.Dto
{
    public sealed record ProdutoResponse(
        int Id,
        string Nome,
        string? Descricao,
        decimal PrecoUnitario,
        int QuantidadeEstoque,
        bool Ativo);

    public sealed record CriarProdutoRequest(
        string Nome,
        string? Descricao,
        decimal PrecoUnitario,
        int QuantidadeInicial);

    public sealed record AtualizarProdutoRequest(
        string Nome,
        string? Descricao,
        decimal PrecoUnitario);
}
