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

        [HttpPost("AdicionarHistoricoPedido")]
        public IActionResult AdicionarHistoricoPedidos([FromBody] HistoricoPedidos p)
        {
            if (p == null)
            {
                return BadRequest("Histórico de pedido inválido.");
            }

            // O mapeamento pode não ser necessário se `p` já for do tipo `HistoricoPedidos`
            HistoricoPedidos historicoPedido = _mapper.Map<HistoricoPedidos>(p);

            _service.Adicionar(historicoPedido);

            return Ok("Histórico de pedido adicionado com sucesso.");
        }

        [HttpGet("VisualizarHistoricoPedidos")]
        public ActionResult<List<ReadHistoricoPedidoDTO>> VisualizarHistoricoPedidos()
        {
            var historicos = _service.Listar();
            return Ok(historicos);
        }
    }
}
