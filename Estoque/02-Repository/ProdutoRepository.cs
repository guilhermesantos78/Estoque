using Dapper;
using Dapper.Contrib.Extensions;
using Estoque.Repository.Data.Script;
using Estoque.Entidades;
using System.Data.SQLite;
using AutoMapper;
using Estoque.Services;
using Microsoft.AspNetCore.Mvc;

namespace Estoque.Repository
{
    public class ProdutoRepository
    {
        public readonly string _connectionString; //Variável de connection string a ser preenchida
        public readonly IMapper _mapper;
        public FornecedorRepository repository { get; set; }
        public ProdutoRepository(IMapper mapper, string ConnectionString) //Responsavel por preencher a connection string
        {
            _connectionString = ConnectionString;
            _mapper = mapper;
            repository = new FornecedorRepository(ConnectionString);
        }
        public void Adicionar(Produto produto)
        {
            using var connection = new SQLiteConnection(_connectionString);

            connection.Execute(ProdutoScript.InsertProduto(), produto);
        }
        public void Remover(int id)
        {
            using var connection = new SQLiteConnection(_connectionString); // conexao
            Produto novoproduto = BuscarProdutoPorId(id);

            connection.Delete<Produto>(novoproduto);
        }
        public void Editar(Produto editProduto)
        {
            using var connection = new SQLiteConnection(_connectionString); // conexao

            connection.Update<Produto>(editProduto);
        }

        public List<ReadProdutoDTO> Listar()
        {
            using var connection = new SQLiteConnection(_connectionString);

            List<Produto> produtos = connection.GetAll<Produto>().ToList();
            List<ReadProdutoDTO> produtosDTO = new List<ReadProdutoDTO>();

            foreach (Produto p in produtos)
            {
                ReadProdutoDTO produtoDTO = new ReadProdutoDTO
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Preco = p.Preco,
                    Descricao = p.Descricao,
                    QuantidadeEmEstoque = p.QuantidadeEmEstoque,
                    FornecedorId = p.FornecedorId,
                    EmpresaId = p.EmpresaId,
                    fornecedorname = repository.BuscarFornecedorNamePorId(p.FornecedorId)
                };

                produtosDTO.Add(produtoDTO);
            }

            return produtosDTO;
        }

        public List<ReadProdutoComFornecedorDTO> VisualizarProdutoInfoFornecedor()
        {
            using var connection = new SQLiteConnection(_connectionString); // conexao
            List<Produto> produto = connection.GetAll<Produto>().ToList();
            List<ReadProdutoComFornecedorDTO> lista = _mapper.Map<List<ReadProdutoComFornecedorDTO>>(produto);

            foreach (ReadProdutoComFornecedorDTO item in lista)
            {
                item.fornecedor = connection.Get<Fornecedor>(item.FornecedorId);
            }

            return lista;
        }

        public Produto BuscarProdutoPorId(int id)
        {
            using var connection = new SQLiteConnection(_connectionString); // conexao

            return connection.Get<Produto>(id);
        }

        public ActionResult<IEnumerable<Produto>> GetProdutosByUsuarioId(int EmpresaId)
        {
            using var connection = new SQLiteConnection(_connectionString); // conexão com SQLite
            connection.Open();

            // Usando Dapper puro para realizar a consulta filtrada por UsuarioId
            string query = "SELECT * FROM Produtos WHERE EmpresaId = @EmpresaId";
            List<Produto> produtos = connection.Query<Produto>(query, new { EmpresaId = EmpresaId }).ToList();

            if (produtos == null || !produtos.Any())
            {
                return NotFound("Nenhum produto encontrado para o usuário especificado."); // Utilizar NotFound ao invés de NotFoundResult
            }

            return Ok(produtos); // Retorna a lista de produtos encontrados
        }

        private ActionResult<IEnumerable<Produto>> NotFound(string mensagem)
        {
            // Aqui você pode retornar uma resposta personalizada para o NotFound
            return new ContentResult
            {
                Content = mensagem,
                ContentType = "text/plain",
                StatusCode = 404
            };
        }

        private ActionResult<IEnumerable<Produto>> Ok(List<Produto> produtos)
        {
            // Aqui você pode retornar a lista de produtos em um formato apropriado
            return new JsonResult(produtos)
            {
                StatusCode = 200 // OK status
            };
        }


    }
}