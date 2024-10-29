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
        private IFornecedorService _service;
        private readonly IMapper _mapper;
        public FornecedorController(IMapper mapper, IConfiguration configuration)
        {
            string ConnectionString = configuration.GetConnectionString("DefaultConnection");
            _service = new FornecedorService(ConnectionString);
            _mapper = mapper;
        }

        [HttpPost("adicionar-fornecedor")] // Rota (EndPoint)
        public void AdicionarFornecedor(CreateFornecedorDTO f)
        {
            Fornecedor fornecedor = _mapper.Map<Fornecedor>(f);

            _service.Adicionar(fornecedor);
        }

        [HttpGet("visualizar-fornecedor")] // Rota (EndPoint)
        public List<Fornecedor> VisualizarFornecedor()
        {
            return _service.Listar();
        }

        [HttpGet("BuscarFornecedorPorId")] // Rota (EndPoint)
        public Fornecedor BuscarFornecedorPorId(int id)
        {
            return _service.BuscarPorId(id);
        }

        [HttpPut("editar-fornecedor")] // Rota (EndPoint)
        public void EditarFornecedor(Fornecedor fornecedor)
        {
            _service.Editar(fornecedor);
        }

        [HttpDelete("remover-fornecedor")] // Rota (EndPoint)
        public void RemoverFornecedor(int id)
        {
            _service.Remover(id);
        }
    }
}
