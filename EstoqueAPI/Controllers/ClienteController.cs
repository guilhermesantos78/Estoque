using AutoMapper;
using Estoque.Entidades;
using Estoque.Services;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueAPI.Controllers
{
    [ApiController]
    [Route("[controller]")] // DataNotation
    public class ClienteController
    {
        private ClienteService _service;
        private readonly IMapper _mapper;
        public ClienteController(IMapper mapper, IConfiguration configuration)
        {
            string ConnectionString = configuration.GetConnectionString("DefaultConnection");
            _service = new ClienteService(ConnectionString);
            _mapper = mapper;
        }

        [HttpPost("adicionar-cliente")] // Rota (EndPoint)
        public void AdicionarFornecedor(CreateClienteDTO c)
        {
            Cliente cliente = _mapper.Map<Cliente>(c);

            _service.Adicionar(cliente);
        }

        [HttpGet("visualizar-cliente")] // Rota (EndPoint)
        public List<Cliente> VisualizarFornecedor()
        {
            return _service.Listar();
        }

        [HttpGet("BuscarClientePorId")] // Rota (EndPoint)
        public Cliente BuscarFornecedorPorId(int id)
        {
            return _service.BuscarClientePorId(id);
        }

        [HttpPut("editar-cliente")] // Rota (EndPoint)
        public void EditarCliente(Cliente cliente)
        {
            _service.Editar(cliente);
        }

        [HttpDelete("remover-cliente")] // Rota (EndPoint)
        public void RemoverClienter(int id)
        {
            _service.Remover(id);
        }

    }
}
