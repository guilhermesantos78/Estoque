using Estoque._01_Services;
using Estoque;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;

namespace EstoqueAPI.Controllers
{
    [ApiController]
    [Route("[controller]")] // DataNotation
    public class FornecedorController : ControllerBase
    {
        private FornecedorService _service;
        public FornecedorController(IConfiguration configuration)
        {
            _service = new FornecedorService(configuration.GetConnectionString("DefaultConnection"));
        }

        [HttpPost("AdicionarFornecedor")] // Rota (EndPoint)
        public void AdicionarFornecedor(Fornecedor fornecedor)
        {
            _service.Adicionar(fornecedor);
        }

        [HttpGet("VisualizarFornecedor")] // Rota (EndPoint)
        public List<Fornecedor> VisualizarFornecedor()
        {
            return _service.Listar();
        }

        [HttpGet("BuscarFornecedorPorId")] // Rota (EndPoint)
        public Fornecedor BuscarFornecedorPorId(int id)
        {
            return _service.BuscarFornecedorPorId(id);
        }

        [HttpPut("EditarFornecedor")] // Rota (EndPoint)
        public void EditarFornecedor(int id, Fornecedor fornecedor)
        {
            _service.Editar(id, fornecedor);
        }

        [HttpDelete("RemoverFornecedor")] // Rota (EndPoint)
        public void RemoverFornecedor(int id)
        {
            _service.Remover(id);
        }
    }
}
