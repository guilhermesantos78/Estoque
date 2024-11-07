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
        [HttpPost("adicionar-empresa")] // Rota (EndPoint)
        public void AdicionarFornecedor(CreateEmpresaDTO c)
        {
            Empresa empresa = _mapper.Map<Empresa>(c);

            _service.Adicionar(empresa);
        }
        /// <summary>
        /// EndPoint para visualizar uma empresa
        /// </summary>
        /// <returns></returns>
        [HttpGet("visualizar-empresa")] // Rota (EndPoint)
        public List<Empresa> VisualizarFornecedor()
        {
            return _service.Listar();
        }
        /// <summary>
        /// EndPoint para buscar uma empresa por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("BuscarEmpresaPorId")] // Rota (EndPoint)
        public Empresa BuscarEmpresaPorId(int id)
        {
            return _service.BuscarPorId(id);
        }
        /// <summary>
        /// EndPoint para Editar uma empresa
        /// </summary>
        /// <param name="empresa"></param>
        [HttpPut("editar-empresa")] // Rota (EndPoint)
        public void EditarEmpresa(Empresa empresa)
        {
            _service.Editar(empresa);
        }
        /// <summary>
        /// EndPoint para Remover uma empresa
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("remover-empresa")] // Rota (EndPoint)
        public void RemoverEmpresa(int id)
        {
            _service.Remover(id);
        }

    }
}
