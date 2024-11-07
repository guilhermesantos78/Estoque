using AutoMapper;
using Estoque.Services;
using Estoque.Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Data.SQLite;
using Microsoft.Data.Sqlite;
using Dapper;

namespace EstoqueAPI.Controllers
{
    [ApiController]
    [Route("[controller]")] // DataNotation
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _service;
        private readonly IMapper _mapper;
        public ProdutoController(IMapper mapper,  IProdutoService service)
        {
            _mapper = mapper;
            _service = service;
        }
        /// <summary>
        /// Endpoint para Adicionar um produto
        /// </summary>
        /// <param name="createprodutoDTO"></param>

        [HttpPost("adicionar-produto")] // Rota (EndPoint)
        public void AdicionarProduto(CreateProdutoDTO createprodutoDTO)
        {
            Produto produto = _mapper.Map<Produto>(createprodutoDTO);

            _service.Adicionar(produto);
        }
        /// <summary>
        /// Endpoint para Visualizar um produto
        /// </summary>
        /// <returns></returns>
        [HttpGet("visualizar-produto")] // Rota (EndPoint)
        public List<ReadProdutoDTO> VisualizarProduto()
        {
            return _service.Listar();
        }
        /// <summary>
        /// Endpoint para Visualizar um produto com a informação do fornecedor
        /// </summary>
        /// <param name="FornecedorId"></param>
        /// <returns></returns>
        [HttpGet("VisualizarProdutoInfoFornecedor")] // Rota (EndPoint)
        public List<ReadProdutoComFornecedorDTO> VisualizarProdutoInfoFornecedor(int FornecedorId)
        {
            return _service.VisualizarProdutoInfoFornecedor();
        }
        /// <summary>
        /// Endpoint para buscar um produto por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Buscar-Por-Id")] // Rota (EndPoint)
        public Produto BuscarProdutoPorId(int id)
        {
            return _service.BuscarProdutoPorId(id);
        }
        /// <summary>
        /// Endpoint para Editar um produto
        /// </summary>
        /// <param name="produto"></param>
        [HttpPut("editar-produto")] // Rota (EndPoint)
        public void Editarproduto(Produto produto)
        {
            _service.Editar(produto);
        }
        /// <summary>
        /// Endpoint para Remover um produto
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("remover-produto")] // Rota (EndPoint)
        public void Removerproduto(int id)
        {
            _service.Remover(id);
        }
        /// <summary>
        /// Endpoint para Buscar um produto pelo id da empresa
        /// </summary>
        /// <param name="UsuarioId"></param>
        /// <returns></returns>
        [HttpGet("cliente/{UsuarioId}")]
        public ActionResult<IEnumerable<Produto>> GetProdutosByUsuarioId(int UsuarioId)
        {
            return _service.GetProdutosByUsuarioId(UsuarioId);
        }

    }
}
