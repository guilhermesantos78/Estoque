using AutoMapper;
using Estoque.Entidades;
using Estoque.Services;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueAPI.Controllers
{
    [ApiController]
    [Route("[controller]")] // DataNotation
    public class EmpresaController : ControllerBase
    {
        private IEmpresaService _service;
        private readonly IMapper _mapper;
        public EmpresaController(IMapper mapper, IEmpresaService service)
        {
            _mapper = mapper;
            _service = service;
        }
        /// <summary> 
        /// EndPoint para adicionar uma empresa
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        [HttpPost("adicionar-empresa")] // Rota (EndPoint)
        public IActionResult AdicionarEmpresa(CreateEmpresaDTO c)
        {
            try
            {
                Empresa empresa = _mapper.Map<Empresa>(c);
                _service.Adicionar(empresa);
                return Ok();
            }
            catch (Exception erro)
            {
                return BadRequest($"Erro ao Adicionar Empresa, O Erro foi {erro.Message}");
            }
        }
        /// <summary>
        /// EndPoint para visualizar uma empresa
        /// </summary>
        /// <returns></returns>
        [HttpGet("visualizar-empresa")] // Rota (EndPoint)
        public List<Empresa> VisualizarFornecedor()
        {
            try
            {
                return _service.Listar();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao visualizar a empresa: {ex.Message}");
            }
        }
        /// <summary>
        /// EndPoint para buscar uma empresa por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("BuscarEmpresaPorId")] // Rota (EndPoint)
        public Empresa BuscarEmpresaPorId(int id)
        {
            try
            {
                return _service.BuscarPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar a empresa por id: {ex.Message}");
            }
        }
        /// <summary>
        /// EndPoint para Editar uma empresa
        /// </summary>
        /// <param name="empresa"></param>
        [HttpPut("editar-empresa")] // Rota (EndPoint)
        public IActionResult EditarEmpresa(Empresa empresa)
        {
            try
            {
                _service.Editar(empresa);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao editar empresa: {ex.Message}");
            }
        }
        /// <summary>
        /// EndPoint para Remover uma empresa
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("remover-empresa")] // Rota (EndPoint)
        public IActionResult RemoverEmpresa(int id)
        {
            try
            {
                _service.Remover(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao remover empresa: {ex.Message}");
            }

        }
    }
}
