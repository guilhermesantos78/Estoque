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
        public IActionResult AdicionarProduto(CreateProdutoDTO createprodutoDTO)
        {
            try
            {
                Produto produto = _mapper.Map<Produto>(createprodutoDTO);
                _service.Adicionar(produto);
                return Ok();
            }
            catch (Exception erro)
            {
                return BadRequest($"Erro ao Adicionar Produto, O Erro foi {erro.Message}");
            }
        }
        /// <summary>
        /// Endpoint para Visualizar um produto
        /// </summary>
        /// <returns></returns>
        [HttpGet("visualizar-produto")] // Rota (EndPoint)
        public List<ReadProdutoDTO> VisualizarProduto()
        {
            try
            {
                return _service.Listar();
            }
            catch (Exception erro)
            {
                throw new Exception($"Erro ao Visualizar Produto, O Erro foi {erro.Message}");
            }
        }
        /// <summary>
        /// Endpoint para Visualizar um produto com a informação do fornecedor
        /// </summary>
        /// <param name="FornecedorId"></param>
        /// <returns></returns>
        [HttpGet("VisualizarProdutoInfoFornecedor")] // Rota (EndPoint)
        public List<ReadProdutoComFornecedorDTO> VisualizarProdutoInfoFornecedor(int FornecedorId)
        {
            try
            {
                return _service.VisualizarProdutoInfoFornecedor();
            }
            catch (Exception erro)
            {
                throw new Exception($"Erro ao Visualizar Produto Info Fornecedor, O Erro foi {erro.Message}");
            }
        }
        /// <summary>
        /// Endpoint para buscar um produto por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Buscar-Por-Id")] // Rota (EndPoint)
        public Produto BuscarProdutoPorId(int id)
        {
            try
            {
                return _service.BuscarProdutoPorId(id);
            }
            catch (Exception erro)
            {
                throw new Exception($"Erro ao Buscar Produto Por Id, O Erro foi {erro.Message}");
            }
        }
        /// <summary>
        /// Endpoint para Editar um produto
        /// </summary>
        /// <param name="produto"></param>
        [HttpPut("editar-produto")] // Rota (EndPoint)
        public IActionResult Editarproduto(Produto produto)
        {
            try
            {
                _service.Editar(produto);
                return Ok();
            }
            catch (Exception erro)
            {
                return BadRequest($"Erro ao Editar Produto, O Erro foi {erro.Message}");
            }
        }
        /// <summary>
        /// Endpoint para Remover um produto
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("remover-produto")] // Rota (EndPoint)
        public IActionResult Removerproduto(int id)
        {
            try
            {
                _service.Remover(id);
                return Ok();
            }
            catch (Exception erro)
            {
                return BadRequest($"Erro ao Remover Produto, O Erro foi {erro.Message}");
            }
        }
        /// <summary>
        /// Endpoint para Buscar um produto pelo id da empresa
        /// </summary>
        /// <param name="UsuarioId"></param>
        /// <returns></returns>
        [HttpGet("cliente/{UsuarioId}")]
        public ActionResult<IEnumerable<Produto>> GetProdutosByUsuarioId(int UsuarioId)
        {
            try
            {
                return _service.GetProdutosByUsuarioId(UsuarioId);
            }
            catch (Exception erro)
            {
                throw new Exception($"Erro ao Visualizar Produtos By Usuario Id, O Erro foi {erro.Message}");
            }
        }


    }
}
