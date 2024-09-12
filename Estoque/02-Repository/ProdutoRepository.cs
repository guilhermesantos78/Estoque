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
        public List<Produto> Listar()
        {
            using var connection = new SQLiteConnection(_connectionString);

            return connection.GetAll<Produto>().ToList();
        }
        public List<ReadProdutoFornecedorDTO> VisualizarPedidoInfoProduto()
        {
            using var connection = new SQLiteConnection(_connectionString); // conexao
            List<Fornecedor> fornecedor = connection.GetAll<Fornecedor>().ToList();
            List<ReadProdutoFornecedorDTO> lista = _mapper.Map<List<ReadProdutoFornecedorDTO>>(fornecedor);

            foreach (ReadProdutoFornecedorDTO item in lista)
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
