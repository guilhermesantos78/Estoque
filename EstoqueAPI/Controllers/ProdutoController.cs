using Estoque;
using Estoque._01_Services;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueAPI.Controllers
{
    [ApiController]
    [Route("[controller]")] // DataNotation
    public class ProdutoController : ControllerBase
    {
        private ProdutoService _service;
        public ProdutoController(IConfiguration configuration)
        {

            _service = new ProdutoService(configuration.GetConnectionString("DefaultConnection"));
        }

        [HttpPost("AdicionarProduto")] // Rota (EndPoint)
        public void AdicionarProduto(Produto produto)
        {
            _service.Adicionar(produto);
        }

        [HttpGet("VisualizarProduto")] // Rota (EndPoint)
        public List<Produto> VisualizarProduto()
        {
            return _service.Listar();
        }

        [HttpGet("BuscarProdutoPorId")] // Rota (EndPoint)
        public Produto BuscarProdutoPorId(int id)
        {
            return _service.BuscarProdutoPorId(id);
        }

        [HttpPut("Editarproduto")] // Rota (EndPoint)
        public void Editarproduto(int id, Produto produto)
        {
            _service.Editar(id, produto);
        }

        [HttpDelete("Removerproduto")] // Rota (EndPoint)
        public void Removerproduto(int id)
        {
            _service.Remover(id);
        }
    }
}
