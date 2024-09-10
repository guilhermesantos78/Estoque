using AutoMapper;
using Estoque._01_Services;
using Estoque._03_Entidades;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueAPI.Controllers
{
    [ApiController]
    [Route("[controller]")] // DataNotation
    public class PedidoController : ControllerBase
    {
        private PedidoService _service;
        private readonly IMapper _mapper;
        public PedidoController(IMapper mapper, IConfiguration configuration)
        {
            string ConnectionString = configuration.GetConnectionString("DefaultConnection");
            _service = new PedidoService(ConnectionString);
            _mapper = mapper;
        }

        [HttpPost("AdicionarPedido")] // Rota (EndPoint)
        public void AdicionarPedido(Pedido p)
        {
            Pedido pedido = _mapper.Map<Pedido>(p);
            _service.Adicionar(pedido);
        }

        [HttpGet("VisualizarPedido")] // Rota (EndPoint)
        public List<Pedido> VisualizarPedido()
        {
            return _service.Listar();
        }

        [HttpGet("BuscarFuncionarioLogPorId")] // Rota (EndPoint)
        public Pedido BuscarPedidoPorId(int id)
        {
            return _service.BuscarPedidoPorId(id);
        }

        [HttpPut("EditarPedido")] // Rota (EndPoint)
        public void EditarPedido(Pedido pedido)
        {
            _service.Editar(pedido);
        }

        [HttpDelete("RemoverPedido")] // Rota (EndPoint)
        public void RemoverPedido(int id)
        {
            _service.Remover(id);
        }
    }
}
