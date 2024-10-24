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
        private EmpresaService _service;
        private readonly IMapper _mapper;
        public EmpresaController(IMapper mapper, IConfiguration configuration)
        {
            string ConnectionString = configuration.GetConnectionString("DefaultConnection");
            _service = new EmpresaService(ConnectionString);
            _mapper = mapper;
        }

        [HttpPost("adicionar-empresa")] // Rota (EndPoint)
        public void AdicionarFornecedor(CreateEmpresaDTO c)
        {
            Empresa empresa = _mapper.Map<Empresa>(c);

            _service.Adicionar(empresa);
        }

        [HttpGet("visualizar-empresa")] // Rota (EndPoint)
        public List<Empresa> VisualizarFornecedor()
        {
            return _service.Listar();
        }

        [HttpGet("BuscarEmpresaPorId")] // Rota (EndPoint)
        public Empresa BuscarEmpresaPorId(int id)
        {
            return _service.BuscarEmpresaPorId(id);
        }

        [HttpPut("editar-empresa")] // Rota (EndPoint)
        public void EditarEmpresa(Empresa empresa)
        {
            _service.Editar(empresa);
        }

        [HttpDelete("remover-empresa")] // Rota (EndPoint)
        public void RemoverEmpresa(int id)
        {
            _service.Remover(id);
        }

    }
}
