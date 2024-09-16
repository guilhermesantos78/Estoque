using AutoMapper;
using Estoque.Entidades;
using Estoque.Services;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HistoricoPedidoController : ControllerBase
    {
        private readonly HistoricoPedidoService _service;
        private readonly IMapper _mapper;

        public HistoricoPedidoController(IMapper mapper, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            _service = new HistoricoPedidoService(mapper, connectionString);
            _mapper = mapper;
        }

        [HttpGet("VisualizarHistoricoPedidos")]
        public List<ReadPedidoComProdutoDTO> VisualizarHistoricoPedidos(int pedidoId)
        {
            return _service.VisualizarHistoricoPedidos();
        }
    }
}
