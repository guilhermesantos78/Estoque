using Estoque._01_Services;
using Estoque;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;
using Estoque._03_Entidades;

namespace EstoqueAPI.Controllers
{
    [ApiController]
    [Route("[controller]")] // DataNotation
    public class FuncionarioLogController : ControllerBase
    {
        private FuncionarioLogService _service;
        public FuncionarioLogController(IConfiguration configuration)
        {
            string ConnectionString = configuration.GetConnectionString("DefaultConnection");
            _service = new FuncionarioLogService(ConnectionString);
            }

        [HttpPost("AdicionarFuncionarioLog")] // Rota (EndPoint)
        public void AdicionarFuncionarioLog(FuncionarioLog funcionario)
        {
            _service.Adicionar(funcionario);
        }

        [HttpGet("VisualizarFuncionarioLog")] // Rota (EndPoint)
        public List<FuncionarioLog> VisualizarFornecedor()
        {
            return _service.Listar();
        }

        [HttpGet("BuscarFuncionarioLogPorId")] // Rota (EndPoint)
        public FuncionarioLog BuscarFuncionarioLogPorId(int id)
        {
            return _service.BuscarFuncionarioLogPorId(id);
        }

        [HttpPut("EditarFuncionarioLog")] // Rota (EndPoint)
        public void EditarFuncionarioLog(FuncionarioLog funcionario)
        {
            _service.Editar(funcionario);
        }

        [HttpDelete("RemoverFuncionarioLog")] // Rota (EndPoint)
        public void RemoverFuncionarioLog(int id)
        {
            _service.Remover(id);
        }
    }
}
