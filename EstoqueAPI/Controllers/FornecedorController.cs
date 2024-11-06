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

        [HttpGet("Buscar-por-Id")] // Rota (EndPoint)
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
