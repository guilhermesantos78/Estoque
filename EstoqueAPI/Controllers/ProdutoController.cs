using AutoMapper;
using Estoque.Services;
using Estoque.Entidades.DTOs.Produto;
using Microsoft.AspNetCore.Mvc;
using Estoque.Entidades;

namespace EstoqueAPI.Controllers
{
    [ApiController]
    [Route("[controller]")] // DataNotation
    public class ProdutoController : ControllerBase
    {
        private ProdutoService _service;
        private readonly IMapper _mapper;
        public ProdutoController(IMapper mapper, IConfiguration configuration)
        {
            string ConnectionString = configuration.GetConnectionString("DefaultConnection");
            _service = new ProdutoService(mapper, ConnectionString);
            _mapper = mapper;
        }

        [HttpPost("AdicionarProduto")] // Rota (EndPoint)
        public void AdicionarProduto(CreateProdutoDTO p)
        {
            Produto produto = _mapper.Map<Produto>(p);

            _service.Adicionar(produto);
        }

        [HttpGet("VisualizarProduto")] // Rota (EndPoint)
        public List<ReadProdutoDTO> VisualizarProduto()
        {
            return _service.Listar();
        }

        [HttpGet("VisualizarProdutoInfoFornecedor")] // Rota (EndPoint)
        public List<ReadProdutoComFornecedorDTO> VisualizarProdutoInfoFornecedor(int FornecedorId)
        {
            return _service.VisualizarProdutoInfoFornecedor();
        }
        [HttpGet("BuscarProdutoPorId")] // Rota (EndPoint)
        public Produto BuscarProdutoPorId(int id)
        {
            return _service.BuscarProdutoPorId(id);
        }

        [HttpPut("Editarproduto")] // Rota (EndPoint)
        public void Editarproduto(Produto produto)
        {
            _service.Editar(produto);
        }

        [HttpDelete("Removerproduto")] // Rota (EndPoint)
        public void Removerproduto(int id)
        {
            _service.Remover(id);
        }
    }
}
