using AutoMapper;
using Estoque.Services;
using Estoque.Entidades;
using Microsoft.AspNetCore.Mvc;
using Estoque.Entidades.DTOs.Pedido;

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
            _service = new PedidoService(mapper, ConnectionString);
            _mapper = mapper;
        }

        [HttpPost("adicionar-pedido")] // Rota (EndPoint)
        public void AdicionarPedido(CreatePedidoDTO p)
        {
            Pedido pedido = _mapper.Map<Pedido>(p);

            _service.Adicionar(pedido);
        }

        [HttpGet("visualizar-pedido")] // Rota (EndPoint)
        public List<Pedido> Listar()
        {
            return _service.Listar();
        }

        [HttpGet("VisualizarPedidoInfoProduto")] // Rota (EndPoint)
        public List<ReadPedidoComProdutoDTO> VisualizarPedidoInfoProduto(int pedidoId)
        {
            return _service.VisualizarPedidoInfoProduto();
        }

        [HttpGet("BuscarPedidoPorId")] // Rota (EndPoint)
        public Pedido BuscarPedidoPorId(int id)
        {
            return _service.BuscarPedidoPorId(id);
        }

        [HttpPut("editar-pedido")] // Rota (EndPoint)
        public void EditarPedido(Pedido pedido)
        {
            _service.Editar(pedido);
        }

        [HttpDelete("remover-pedido")] // Rota (EndPoint)
        public void RemoverPedido(int id)
        {
            _service.Remover(id);
        }
    }
}
