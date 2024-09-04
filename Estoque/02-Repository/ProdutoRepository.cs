using Microsoft.Extensions.Configuration;
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
        public readonly string _ConnectionString; //Variável de connection string a ser preenchida

        public ProdutoRepository(IConfiguration configuration) //Responsavel por preencher a connection string
        {
            _ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public void Adicionar(Produto produto)
        {
            using (var connection = new SQLiteConnection(_ConnectionString)) // Criando a conexão
            {
                connection.Open();

                // Comando para inserir dados nas tabelas
                string commandInsert = @"
                INSERT INTO Produtos(Nome, Preco, Descricao, QuantidadeEmEstoque , FornecedorId)
                VALUES (@Nome, @Preco, @Descricao , @QuantidadeEmEstoque, @FornecedorId)";

                using (var command = new SQLiteCommand(commandInsert, connection))
                {
                    command.Parameters.AddWithValue("@Nome", produto.Nome); // Substitui a chave no comando para a variável do parâmetro
                    command.Parameters.AddWithValue("@Preco", produto.Preco);
                    command.Parameters.AddWithValue("@Descricao", produto.Descricao);
                    command.Parameters.AddWithValue("@QuantidadeEmEstoque", produto.QuantidadeEmEstoque);
                    command.Parameters.AddWithValue("@FornecedorId", produto.FornecedorId);
                    command.ExecuteNonQuery();
                }
            }
        }


        public void Remover(int id)
        {
            using (var connection = new SQLiteConnection(_ConnectionString)) // Criando a conexão
            {
                connection.Open();

                // Comando para deletar os dados das tabelas
                string commandDelete = "DELETE FROM Produtos WHERE Id = @Id";

                using (var command = new SQLiteCommand(commandDelete, connection))
                {
                    command.Parameters.AddWithValue("@Id", id); // Substitui a chave no comando para a variável do parâmetro
                    command.ExecuteNonQuery();
                }

            }
        }


        public void Editar(int id, Produto editProduto)
        {
            using (var connection = new SQLiteConnection(_ConnectionString)) // Criando a conexão
            {
                connection.Open();

                // Comando para editar os dados das tabelas
                string commandUptade = @"
                UPDATE Produtos
                SET Nome = @Nome, Preco = @Preco, Descricao = @Descricao, QuantidadeEmEstoque = @QuantidadeEmEstoque, FornecedorId = @FornecedorId
                WHERE Id = @Id";

                using (var command = new SQLiteCommand(commandUptade, connection))
                {
                    command.Parameters.AddWithValue("@Id", id); // Substitui a chave no comando para a variável do parâmetro
                    command.Parameters.AddWithValue("@Nome", editProduto.Nome); // Substitui a chave no comando para a variável do parâmetro
                    command.Parameters.AddWithValue("@Preco", editProduto.Preco);
                    command.Parameters.AddWithValue("@Descricao", editProduto.Descricao);
                    command.Parameters.AddWithValue("@QuantidadeEmEstoque", editProduto.QuantidadeEmEstoque);
                    command.Parameters.AddWithValue("@FornecedorId", editProduto.FornecedorId);
                    command.ExecuteNonQuery();
                }
            }
        }


        public List<Produto> Listar()
        {
            List<Produto> listAux = new List<Produto>();

            using (var connection = new SQLiteConnection(_ConnectionString)) // Criando a conexão
            {
                connection.Open();

                // Comando para selecionar e exibir os dados das tabelas
                string commandSelectId = "SELECT Id, Nome, Preco, Descricao, QuantidadeEmEstoque , FornecedorId FROM Produtos;";

                using (var command = new SQLiteCommand(commandSelectId, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Produto ProdutoAux = new Produto();
                            ProdutoAux.Id = int.Parse(reader["Id"].ToString());
                            ProdutoAux.Nome = reader["Nome"].ToString();
                            ProdutoAux.Preco = int.Parse(reader["Preco"].ToString());
                            ProdutoAux.Descricao = reader["Descricao"].ToString();
                            ProdutoAux.QuantidadeEmEstoque = int.Parse(reader["QuantidadeEmEstoque"].ToString());
                            ProdutoAux.FornecedorId = int.Parse(reader["FornecedorId"].ToString());

                            listAux.Add(ProdutoAux);

                        }
                    }
                }
            }
            return listAux;
        }


        public Produto BuscarProdutoPorId(int id)
        {
            using (var connection = new SQLiteConnection(_ConnectionString)) // Criando a conexão
            {
                connection.Open();

                // Comando para selecionar e exibir os dados das tabelas
                string commandSelectId = "SELECT Id, Nome, Preco, Descricao, QuantidadeEmEstoque , FornecedorId FROM Produtos WHERE Id = @Id;";

                using (var command = new SQLiteCommand(commandSelectId, connection))
                {
                    command.Parameters.AddWithValue("@Id", id); // Substitui a chave no comando para a variável do parâmetro

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Produto ProdutoAux = new Produto();
                            ProdutoAux.Id = int.Parse(reader["Id"].ToString());
                            ProdutoAux.Nome = reader["Nome"].ToString();
                            ProdutoAux.Preco = int.Parse(reader["Preco"].ToString());
                            ProdutoAux.Descricao = reader["Descricao"].ToString();
                            ProdutoAux.QuantidadeEmEstoque = int.Parse(reader["QuantidadeEmEstoque"].ToString());
                            ProdutoAux.FornecedorId = int.Parse(reader["FornecedorId"].ToString());

                            return ProdutoAux;
                        }
                    }
                }
            }
            return null;
        }
    }
}
