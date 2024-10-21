using Dapper;
using Dapper.Contrib.Extensions;
using Estoque.Entidades;
using System.Data.SQLite;

namespace Estoque.Repository
{
    public class ClienteRepository
    {
        public readonly string _connectionString; //Variável de connection string a ser preenchida


        public ClienteRepository(string ConnectionString) //Responsavel por preencher a connection string
        {
            _connectionString = ConnectionString;
        }

        public void Adicionar(Cliente cliente)
        {
            using var connection = new SQLiteConnection(_connectionString);

            connection.Execute(ClienteScript.InsertCliente(), cliente);
        }

        public void Remover(int id)
        {
            using var connection = new SQLiteConnection(_connectionString); // conexao
            Cliente novoCliente = BuscarClientePorId(id);

            connection.Delete<Cliente>(novoCliente);
        }

        public void Editar(Cliente editCliente)
        {
            using var connection = new SQLiteConnection(_connectionString); // conexao

            connection.Update<Cliente>(editCliente);
        }

        public List<Cliente> Listar()
        {
            using var connection = new SQLiteConnection(_connectionString);// conexao

            return connection.GetAll<Cliente>().ToList();
        }

        public Cliente BuscarClientePorId(int id)
        {
            using var connection = new SQLiteConnection(_connectionString);

            return connection.Get<Cliente>(id);
        }

    }
}
