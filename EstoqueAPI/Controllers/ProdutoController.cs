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
        public ProdutoController(IMapper mapper, IProdutoService service)
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
        public ActionResult<List<ReadProdutoDTO>> VisualizarProduto()
        {
            try
            {
                List<ReadProdutoDTO> produtos = _service.Listar();
                if (produtos == null || !produtos.Any())
                {
                    return NotFound("Nenhum produto encontrado.");
                }
                return Ok(produtos);
            }
            catch (Exception erro)
            {
                return BadRequest($"Erro ao Visualizar Produto, O Erro foi {erro.Message}");
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
        public ActionResult<Produto> BuscarProdutoPorId(int id)
        {
            try
            {
                var produto = _service.BuscarProdutoPorId(id);
                if (produto == null)
                {
                    return NotFound($"Produto com ID {id} não encontrado.");
                }
                return Ok(produto);
            }
            catch (Exception erro)
            {
                return BadRequest($"Erro ao Buscar Produto Por Id, O Erro foi {erro.Message}");
            }
        }

        /// <summary>
        /// Endpoint para Editar um produto
        /// </summary>
        /// <param name="produto"></param>
        [HttpPut("editar-produto")] // Rota (EndPoint)
        public IActionResult Editarproduto([FromBody] Produto produto, [FromQuery] int EmpresaId)
        {
            try
            {
                int prodId = produto.Id;
                Produto prod = _service.BuscarProdutoPorId(prodId);

                if (EmpresaId == prod.EmpresaId)
                {
                    _service.Editar(produto);
                    return Ok();
                }
                else
                {
                    return BadRequest($"Erro ao Remover Produto. voce nao tem um produto com esse id Cadastrado");
                }
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
        public IActionResult RemoverProduto(int id, [FromQuery] int EmpresaId)
        {
            try
            {
                Produto produto = _service.BuscarProdutoPorId(id);
                if (produto == null)
                {
                    return NotFound($"Produto com ID {id} não encontrado.");
                }

                if (produto.EmpresaId != EmpresaId)
                {
                    return BadRequest("Você não tem permissão para remover este produto.");
                }

                _service.Remover(id);
                return Ok($"Produto com ID {id} removido com sucesso.");
            }
            catch (Exception erro)
            {
                return BadRequest($"Erro ao Remover Produto, O Erro foi {erro.Message}");
            }
        }

        /// <summary>
        /// Endpoint para Buscar um produto pelo id da empresa
        /// </summary>
        /// <param name="EmpresaId"></param>
        /// <returns></returns>
        [HttpGet("cliente/{EmpresaId}")]
        public ActionResult<IEnumerable<Produto>> GetProdutosByEmpresaId(int EmpresaId)
        {
            try
            {
                return _service.GetProdutosByEmpresaId(EmpresaId);
            }
            catch (Exception erro)
            {
                throw new Exception($"Erro ao Visualizar Produtos By Usuario Id, O Erro foi {erro.Message}");
            }
        }


    }
}
