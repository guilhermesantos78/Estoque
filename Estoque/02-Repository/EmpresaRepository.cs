using Dapper;
using Dapper.Contrib.Extensions;
using Estoque.Entidades;
using System.Data.SQLite;

namespace Estoque.Repository
{
    public class EmpresaRepository : IEmpresaRepository
    {
        public readonly string _connectionString; //Variável de connection string a ser preenchida


        public EmpresaRepository(string ConnectionString) //Responsavel por preencher a connection string
        {
            _connectionString = ConnectionString;
        }

        public void Adicionar(Empresa empresa)
        {
            using var connection = new SQLiteConnection(_connectionString);

            connection.Execute(EmpresaScript.InsertEmpresa(), empresa);
        }

        public void Remover(int id)
        {
            using var connection = new SQLiteConnection(_connectionString); // conexao
            Empresa novaEmpresa = BuscarPorId(id);

            connection.Delete<Empresa>(novaEmpresa);
        }

        public void Editar(Empresa editEmpresa)
        {
            using var connection = new SQLiteConnection(_connectionString); // conexao

            connection.Update<Empresa>(editEmpresa);
        }

        public List<Empresa> Listar()
        {
            using var connection = new SQLiteConnection(_connectionString);// conexao

            return connection.GetAll<Empresa>().ToList();
        }

        public Empresa BuscarPorId(int id)
        {
            using var connection = new SQLiteConnection(_connectionString);

            return connection.Get<Empresa>(id);
        }

    }
}
