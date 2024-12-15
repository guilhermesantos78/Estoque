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
        public IActionResult AdicionarPedido(CreatePedidoDTO p)
        {
            try
            {
                Pedido pedido = _mapper.Map<Pedido>(p);
                _service.Adicionar(pedido);
                return Ok();
            }
            catch (Exception erro)
            {
                return BadRequest($"Erro ao Adicionar Pedido, O Erro foi {erro.Message}");
            }
        }
        /// <summary>
        /// EndPoint para Visualizar um pedido
        /// </summary>
        /// <returns></returns>
        [HttpGet("visualizar-pedido")] // Rota (EndPoint)
        public List<Pedido> Listar()
        {

            try
            {
                return _service.Listar();
            }
            catch (Exception erro)
            {
                throw new Exception($"Erro ao Listar Pedidos, O Erro foi {erro.Message}");
            }
        }
        /// <summary>
        /// EndPoint para Visualizar um pedido com informação do produto
        /// </summary>
        /// <param name="pedidoId"></param>
        /// <returns></returns>
        [HttpGet("VisualizarPedidoInfoProduto")] // Rota (EndPoint)
        public List<ReadPedidoComProdutoDTO> VisualizarPedidoInfoProduto(int pedidoId)
        {

            try
            {
                return _service.VisualizarPedidoInfoProduto();
            }
            catch (Exception erro)
            {
                throw new Exception($"Erro ao Visualizar Pedido Info Produto, O Erro foi {erro.Message}");
            }
        }
        /// <summary>
        /// EndPoint para Buscar um pedido por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("BuscarPedidoPorId")] // Rota (EndPoint)
        public Pedido BuscarPedidoPorId(int id)
        {

            try
            {
                return _service.BuscarPorId(id);
            }
            catch (Exception erro)
            {
                throw new Exception($"Erro ao Buscar Pedido Por Id, O Erro foi {erro.Message}");
            }
        }
        /// <summary>
        /// EndPoint para Editar um pedido
        /// </summary>
        /// <param name="pedido"></param>
        [HttpPut("editar-pedido")] // Rota (EndPoint)
        public IActionResult EditarPedido(Pedido pedido)
        {
            try
            {
                _service.Editar(pedido);
                return Ok();
            }
            catch (Exception erro)
            {
                return BadRequest($"Erro ao Editar Pedido, O Erro foi {erro.Message}");
            }
        }
        /// <summary>
        /// EndPoint para Remover um pedido
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("remover-pedido")] // Rota (EndPoint)
        public IActionResult RemoverPedido(int id)
        {

            try
            {
                _service.Remover(id);
                return Ok();
            }
            catch (Exception erro)
            {
                return BadRequest($"Erro ao Remover Pedido, O Erro foi {erro.Message}");
            }
        }

        /// <summary>
        /// Endpoint para Buscar um produto pelo id da empresa
        /// </summary>
        /// <param name="EmpresaId"></param>
        /// <returns></returns>
        [HttpGet("pedido/{EmpresaId}")]
        public ActionResult<IEnumerable<Pedido>> GetProdutosByEmpresaId(int EmpresaId)
        {
            try
            {
                return _service.GetPedidosByEmpresaId(EmpresaId);
            }
            catch (Exception erro)
            {
                throw new Exception($"Erro ao Visualizar Pedido By Usuario Id, O Erro foi {erro.Message}");
            }
        }

    }
}
