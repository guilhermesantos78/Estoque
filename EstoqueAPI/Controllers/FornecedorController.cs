using AutoMapper;
using Estoque.Services;
using Microsoft.AspNetCore.Mvc;
using Estoque.Entidades;

namespace EstoqueAPI.Controllers
{
    [ApiController]
    [Route("[controller]")] // DataNotation
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorService _service;
        private readonly IMapper _mapper;
        public FornecedorController(IMapper mapper, IFornecedorService service)
        {
            _mapper = mapper;
            _service = service;
        }
        /// <summary>
        /// Endpoint para Adicionar um fornecedor
        /// </summary>
        /// <param name="f"></param>
        [HttpPost("adicionar-fornecedor")] // Rota (EndPoint)
        public IActionResult AdicionarFornecedor(CreateFornecedorDTO f)
        {

            try
            {
                Fornecedor fornecedor = _mapper.Map<Fornecedor>(f);
                _service.Adicionar(fornecedor);
                return Ok();
            }
            catch (Exception erro)
            {
                return BadRequest($"Erro ao Adicionar Fornecedor, O Erro foi {erro.Message}");
            }
        }
        /// <summary>
        /// Endpoint para Visualizar um fornecedor
        /// </summary>
        /// <returns></returns>
        [HttpGet("visualizar-fornecedor")] // Rota (EndPoint)
        public List<Fornecedor> VisualizarFornecedor()
        {

            try
            {
                return _service.Listar();
            }
            catch (Exception erro)
            {
                throw new Exception($"Erro ao Visualizar Fornecedor, O Erro foi {erro.Message}");
            }
        }
        /// <summary>
        /// Endpoint para Buscar um fornecedor por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Buscar-por-Id")] // Rota (EndPoint)
        public Fornecedor BuscarFornecedorPorId(int id)
        {

            try
            {
                return _service.BuscarPorId(id);
            }
            catch (Exception erro)
            {
                throw new Exception($"Erro ao Buscar Fornecedor Por Id, O Erro foi {erro.Message}");
            }
        }
        /// <summary>
        /// Endpoint para Editar um fornecedor
        /// </summary>
        /// <param name="fornecedor"></param>
        [HttpPut("editar-fornecedor")] // Rota (EndPoint)
        public void EditarFornecedor(Fornecedor fornecedor)
        {
            try
            {
                _service.Editar(fornecedor);
            }
            catch (Exception erro)
            {
                throw new Exception($"Erro ao Editar Fornecedor, O Erro foi {erro.Message}");
            }
        }
        /// <summary>
        /// Endpoint para Remover um fornecedor
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("remover-fornecedor")] // Rota (EndPoint)
        public IActionResult RemoverFornecedor(int id)
        {

            try
            {
                _service.Remover(id);
                return Ok();
            }
            catch (Exception erro)
            {
                return BadRequest($"Erro ao Remover Fornecedor, O Erro foi {erro.Message}");
            }
        }

        /// <summary>
        /// Endpoint para Buscar um produto pelo id da empresa
        /// </summary>
        /// <param name="UsuarioId"></param>
        /// <returns></returns>
        [HttpGet("fornecedor/{UsuarioId}")]
        public ActionResult<IEnumerable<Fornecedor>> GetFornecedorByEmpresaId(int UsuarioId)
        {
            try
            {
                return _service.GetFornecedorByEmpresaId(UsuarioId);
            }
            catch (Exception erro)
            {
                throw new Exception($"Erro ao Visualizar Fornecedor By Usuario Id, O Erro foi {erro.Message}");
            }
        }
    }
}
