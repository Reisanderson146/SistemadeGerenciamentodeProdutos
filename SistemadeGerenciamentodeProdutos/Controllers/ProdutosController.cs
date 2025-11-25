using Microsoft.AspNetCore.Mvc;
using SistemadeGerenciamentodeProdutos.Application.Produtos.Dto;
using SistemadeGerenciamentodeProdutos.Application.Produtos.Interfaces;

namespace SistemadeGerenciamentodeProdutos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProdutoResponse>>> Get()
        {
            var produtos = await _produtoService.ObterTodosAsync();
            return Ok(produtos);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProdutoResponse>> GetById(int id)
        {
            var produto = await _produtoService.ObterPorIdAsync(id);
            if (produto is null)
                return NotFound();

            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoResponse>> Post([FromBody] CriarProdutoRequest request)
        {
            try
            {
                var criado = await _produtoService.CriarAsync(request);
                return CreatedAtAction(nameof(GetById), new { id = criado.Id }, criado);
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody] AtualizarProdutoRequest request)
        {
            try
            {
                var atualizado = await _produtoService.AtualizarAsync(id, request);
                if (!atualizado)
                    return NotFound();

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var removido = await _produtoService.RemoverAsync(id);
            if (!removido)
                return NotFound();

            return NoContent();
        }
    }
}
