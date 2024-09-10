using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque._02_Repository
{
    public class ProdutoRepository
    {
        public readonly string _connectionString; //Variável de connection string a ser preenchida

        public ProdutoRepository(string ConnectionString) //Responsavel por preencher a connection string
        {
            _connectionString = ConnectionString;
        }
        public void Adicionar(Produto produto)
        {
            using var connection = new SQLiteConnection(_connectionString);

            string commandInsert = @"
                INSERT INTO Produtos(Nome, Preco, Descricao, QuantidadeEmEstoque , FornecedorId)
                VALUES (@Nome, @Preco, @Descricao , @QuantidadeEmEstoque, @FornecedorId)";

            connection.Execute(commandInsert, produto);
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
            using var connection = new SQLiteConnection(_connectionString);// conexao
            return connection.GetAll<Produto>().ToList();
        }


        public Produto BuscarProdutoPorId(int id)
        {
            using var connection = new SQLiteConnection(_connectionString);// conexao
            return connection.Get<Produto>(id);
        }

    }
}
