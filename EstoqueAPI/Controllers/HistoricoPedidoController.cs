using AutoMapper;
using Estoque.Services;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HistoricoPedidoController : ControllerBase
    {
        private readonly IHistoricoPedidoService _service;
        private readonly IMapper _mapper;

        public HistoricoPedidoController(IMapper mapper, IHistoricoPedidoService service)
        {
            _mapper = mapper;
            _service = service;
        }
        /// <summary>
        /// Endpoint para Visualizar o historico de Pedidos
        /// </summary>
        /// <param name="pedidoId"></param>
        /// <returns></returns>
        [HttpGet("VisualizarHistoricoPedidos")]
        public List<ReadPedidoComProdutoDTO> VisualizarHistoricoPedidos(int pedidoId)
        {
            return _service.VisualizarHistoricoPedidos();
        }
    }
}
