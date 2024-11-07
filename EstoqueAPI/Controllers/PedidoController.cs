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
        private readonly IPedidoService _service;
        private readonly IMapper _mapper;
        public PedidoController(IMapper mapper, IConfiguration configuration, IPedidoService service)
        {
            _mapper = mapper;
            _service = service;
        }
        /// <summary>
        /// EndPoint para Adicionar um pedido
        /// </summary>
        /// <param name="p"></param>
        [HttpPost("adicionar-pedido")] // Rota (EndPoint)
        public void AdicionarPedido(CreatePedidoDTO p)
        {
            Pedido pedido = _mapper.Map<Pedido>(p);

            _service.Adicionar(pedido);
        }
        /// <summary>
        /// EndPoint para Visualizar um pedido
        /// </summary>
        /// <returns></returns>
        [HttpGet("visualizar-pedido")] // Rota (EndPoint)
        public List<Pedido> Listar()
        {
            return _service.Listar();
        }
        /// <summary>
        /// EndPoint para Visualizar um pedido com informação do produto
        /// </summary>
        /// <param name="pedidoId"></param>
        /// <returns></returns>
        [HttpGet("VisualizarPedidoInfoProduto")] // Rota (EndPoint)
        public List<ReadPedidoComProdutoDTO> VisualizarPedidoInfoProduto(int pedidoId)
        {
            return _service.VisualizarPedidoInfoProduto();
        }
        /// <summary>
        /// EndPoint para Buscar um pedido por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("BuscarPedidoPorId")] // Rota (EndPoint)
        public Pedido BuscarPedidoPorId(int id)
        {
            return _service.BuscarPorId(id);
        }
        /// <summary>
        /// EndPoint para Editar um pedido
        /// </summary>
        /// <param name="pedido"></param>
        [HttpPut("editar-pedido")] // Rota (EndPoint)
        public void EditarPedido(Pedido pedido)
        {
            _service.Editar(pedido);
        }
        /// <summary>
        /// EndPoint para Remover um pedido
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("remover-pedido")] // Rota (EndPoint)
        public void RemoverPedido(int id)
        {
            _service.Remover(id);
        }
    }
}
