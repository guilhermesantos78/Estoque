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
        [HttpGet("visualizar-fornecedor")]
        public ActionResult<List<Fornecedor>> VisualizarFornecedor()
        {
            try
            {
                var fornecedores = _service.Listar();
                if (fornecedores == null || !fornecedores.Any())
                {
                    return NotFound("Nenhum fornecedor encontrado.");
                }
                return Ok(fornecedores);
            }
            catch (Exception erro)
            {
                return BadRequest($"Erro ao visualizar fornecedores, O erro foi: {erro.Message}");
            }
        }


        /// <summary>
        /// Endpoint para Buscar um fornecedor por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Buscar-por-Id")]
        public ActionResult<Fornecedor> BuscarFornecedorPorId(int id)
        {
            try
            {
                var fornecedor = _service.BuscarPorId(id);
                if (fornecedor == null)
                {
                    return NotFound("Fornecedor não encontrado.");
                }
                return Ok(fornecedor);
            }
            catch (Exception erro)
            {
                return BadRequest($"Erro ao Buscar Fornecedor Por Id, O Erro foi {erro.Message}");
            }
        }


        /// <summary>
        /// Endpoint para Editar um fornecedor
        /// </summary>
        /// <param name="fornecedor"></param>
        [HttpPut("editar-fornecedor")] // Rota (EndPoint)
        public void EditarFornecedor([FromBody] Fornecedor fornecedor, [FromQuery] int EmpresaId)
        {
            try
            {
                int fornId = fornecedor.Id;
                Fornecedor forn = BuscarFornecedorPorId(fornId).Value;

                if (forn.EmpresaId == EmpresaId)
                {
                    _service.Editar(fornecedor);
                }
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
        [HttpDelete("remover-fornecedor")]
        public IActionResult RemoverFornecedor(int id, [FromQuery] int EmpresaId)
        {
            try
            {
                Fornecedor fornecedor = BuscarFornecedorPorId(id).Value;

                if (fornecedor.EmpresaId == EmpresaId)
                {
                    _service.Remover(id);
                    return Ok($"Fornecedor com ID {id} removido com sucesso.");
                }
                return Unauthorized("Empresa não tem permissão para remover esse fornecedor.");
            }
            catch (Exception erro)
            {
                return BadRequest($"Erro ao Remover Fornecedor, O Erro foi {erro.Message}");
            }
        }



        /// <summary>
        /// Endpoint para Buscar um produto pelo id da empresa
        /// </summary>
        /// <param name="EmpresaId"></param>
        /// <returns></returns>
        [HttpGet("fornecedor/{EmpresaId}")]
        public ActionResult<IEnumerable<Fornecedor>> GetFornecedorByEmpresaId(int EmpresaId)
        {
            try
            {
                return _service.GetFornecedorByEmpresaId(EmpresaId);
            }
            catch (Exception erro)
            {
                throw new Exception($"Erro ao Visualizar Fornecedor By Usuario Id, O Erro foi {erro.Message}");
            }
        }
    }
}
