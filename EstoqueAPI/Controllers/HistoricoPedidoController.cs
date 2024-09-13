using AutoMapper;
using Estoque.Entidades;
using Estoque.Services;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueAPI.Controllers
{
    [ApiController]
    [Route("[controller]")] // DataNotation
    public class HistoricoPedidoController : ControllerBase
    {
        private HistoricoPedidoService _service;
        private readonly IMapper _mapper;
        public HistoricoPedidoController(IMapper mapper, IConfiguration configuration)
        {
            string ConnectionString = configuration.GetConnectionString("DefaultConnection");
            _service = new HistoricoPedidoService(ConnectionString);
            _mapper = mapper;
        }

        [HttpPost("AdicionarHistoricoPedido")] // Rota (EndPoint)
        public void AdicionarHistoricoPedidos(HistoricoPedidos p)
        {
            HistoricoPedidos historicopedido = _mapper.Map<HistoricoPedidos>(p);

            _service.Adicionar(historicopedido);
        }

        [HttpGet("VisualizarHistoricoPedidos")] // Rota (EndPoint)
        public List<HistoricoPedidos> VisualizarHistoricoPedidos()
        {
            return _service.Listar();
        }

        [HttpGet("BuscarFornecedorPorId")] // Rota (EndPoint)
        public Fornecedor BuscarFornecedorPorId(int id)
        {
            return _service.BuscarFornecedorPorId(id);
        }

        [HttpPut("EditarFornecedor")] // Rota (EndPoint)
        public void EditarFornecedor(Fornecedor fornecedor)
        {
            _service.Editar(fornecedor);
        }

        [HttpDelete("RemoverFornecedor")] // Rota (EndPoint)
        public void RemoverFornecedor(int id)
        {
            _service.Remover(id);
        }
    }
}
