using Dapper;
using Dapper.Contrib.Extensions;
using Estoque.Repository.Data.Script;
using Estoque.Entidades;
using System.Data.SQLite;
using AutoMapper;
using Estoque.Services;

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
            List<Produto> rotinas = connection.GetAll<Produto>().ToList();
            List<ReadProdutoDTO> produtosDTO = new List<ReadProdutoDTO>();//_mapper.Map<List<ReadRotinaDTO>>(lista);
            foreach (Produto p in rotinas)
            {
                ReadProdutoDTO produtoDTO = new ReadProdutoDTO();
                produtoDTO.Id = p.Id;
                produtoDTO.Nome = p.Nome;
                produtoDTO.Preco = p.Preco;
                produtoDTO.Descricao = p.Descricao;
                produtoDTO.QuantidadeEmEstoque = p.QuantidadeEmEstoque;
                produtoDTO.FornecedorId = p.FornecedorId;
                produtoDTO.fornecedor = repository.BuscarFornecedorPorId(p.FornecedorId);
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
    }
}