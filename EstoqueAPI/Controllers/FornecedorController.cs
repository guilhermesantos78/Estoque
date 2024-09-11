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
        private FornecedorService _service;
        private readonly IMapper _mapper;
        public FornecedorController(IMapper mapper, IConfiguration configuration)
        {
            string ConnectionString = configuration.GetConnectionString("DefaultConnection");
            _service = new FornecedorService(ConnectionString);
            _mapper = mapper;
        }

        [HttpPost("AdicionarFornecedor")] // Rota (EndPoint)
        public void AdicionarFornecedor(CreateFornecedorDTO f)
        {
            Fornecedor fornecedor = _mapper.Map<Fornecedor>(f);

            _service.Adicionar(fornecedor);
        }

        [HttpGet("VisualizarFornecedor")] // Rota (EndPoint)
        public List<Fornecedor> VisualizarFornecedor()
        {
            return _service.Listar();
        }

        [HttpGet("BuscarFornecedorPorId")] // Rota (EndPoint)
        public Fornecedor BuscarFornecedorPorId(int id)
        {
            return _service.BuscarFornecedorPorId(id);
        }

        [HttpPut("EditarFornecedor")] // Rota (EndPoint)
        public void EditarFornecedor(Fornecedor fornecedor)
        {
            _service.Editar(fornecedor);
        }

        [HttpDelete("RemoverFornecedor")] // Rota (EndPoint)
        public void RemoverFornecedor(int id)
        {
            _service.Remover(id);
        }
    }
}
