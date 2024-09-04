using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque._02_Repository
{
    public class FornecedorRepository
    {
        public readonly string _ConnectionString; //Variável de connection string a ser preenchida

        public FornecedorRepository(IConfiguration configuration) //Responsavel por preencher a connection string
        {
            _ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public void Adicionar(Fornecedor fornecedor)
        {
            using (var connection = new SQLiteConnection(_ConnectionString)) // Criando a conexão
            {
                connection.Open();

                // Comando para inserir dados nas tabelas
                string commandInsert = @"
                INSERT INTO Fornecedores(Nome, Contato, Endereco, CNPJ)
                VALUES (@Nome, @Contato, @Endereco , @CNPJ)";

                using (var command = new SQLiteCommand(commandInsert, connection))
                {
                    command.Parameters.AddWithValue("@Nome", fornecedor.Nome); // Substitui a chave no comando para a variável do parâmetro
                    command.Parameters.AddWithValue("@Contato", fornecedor.Contato);
                    command.Parameters.AddWithValue("@Endereco", fornecedor.Endereco);
                    command.Parameters.AddWithValue("@CNPJ", fornecedor.CNPJ);
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
                string commandDelete = "DELETE FROM Fornecedores WHERE Id = @Id";

                using (var command = new SQLiteCommand(commandDelete, connection))
                {
                    command.Parameters.AddWithValue("@Id", id); // Substitui a chave no comando para a variável do parâmetro
                    command.ExecuteNonQuery();
                }

            }
        }


        public void Editar(int id, Fornecedor editFornecedor)
        {
            using (var connection = new SQLiteConnection(_ConnectionString)) // Criando a conexão
            {
                connection.Open();

                // Comando para editar os dados das tabelas
                string commandUptade = @"
                UPDATE Produtos
                SET Nome = @Nome, Preco = @Preco, Descricao = @Descricao, QuantidadeEmEstoque = @QuantidadeEmEstoque
                WHERE Id = @Id";

                using (var command = new SQLiteCommand(commandUptade, connection))
                {
                    command.Parameters.AddWithValue("@Id", id); // Substitui a chave no comando para a variável do parâmetro
                    command.Parameters.AddWithValue("@Nome", editFornecedor.Nome); // Substitui a chave no comando para a variável do parâmetro
                    command.Parameters.AddWithValue("@Contato", editFornecedor.Contato);
                    command.Parameters.AddWithValue("@Endereco", editFornecedor.Endereco);
                    command.Parameters.AddWithValue("@CNPJ", editFornecedor.CNPJ);
                    command.ExecuteNonQuery();
                }
            }
        }


        public List<Fornecedor> Listar()
        {
            List<Fornecedor> listAux = new List<Fornecedor>();

            using (var connection = new SQLiteConnection(_ConnectionString)) // Criando a conexão
            {
                connection.Open();

                // Comando para selecionar e exibir os dados das tabelas
                string commandSelectId = "SELECT Id, Nome, Contato, Endereco, CNPJ FROM Fornecedores;";

                using (var command = new SQLiteCommand(commandSelectId, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Fornecedor FornecedorAux = new Fornecedor();
                            FornecedorAux.Id = int.Parse(reader["Id"].ToString());
                            FornecedorAux.Nome = reader["Nome"].ToString();
                            FornecedorAux.Contato = reader["Contato"].ToString();
                            FornecedorAux.Endereco = reader["Endereco"].ToString();
                            FornecedorAux.CNPJ = reader["CNPJ"].ToString();

                            listAux.Add(FornecedorAux);

                        }
                    }
                }
            }
            return listAux;
        }


        public Fornecedor BuscarFornecedorPorId(int id)
        {
            using (var connection = new SQLiteConnection(_ConnectionString)) // Criando a conexão
            {
                connection.Open();

                // Comando para selecionar e exibir os dados das tabelas
                string commandSelectId = "SELECT Id, Nome, Contato, Endereco, CNPJ FROM Fornecedores WHERE Id = @Id;";

                using (var command = new SQLiteCommand(commandSelectId, connection))
                {
                    command.Parameters.AddWithValue("@Id", id); // Substitui a chave no comando para a variável do parâmetro

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Fornecedor FornecedorAux = new Fornecedor();
                            FornecedorAux.Id = int.Parse(reader["Id"].ToString());
                            FornecedorAux.Nome = reader["Nome"].ToString();
                            FornecedorAux.Contato = reader["Contato"].ToString();
                            FornecedorAux.Endereco = reader["Endereco"].ToString();
                            FornecedorAux.CNPJ = reader["CNPJ"].ToString();

                            return FornecedorAux;
                        }
                    }
                }
            }
            return null;
        }
    }
}
