using AutoMapper;
using Dapper.Contrib.Extensions;
using Estoque.Entidades;
using System.Data.SQLite;

namespace Estoque.Repository
{
    public class UsuarioRepository
    {
        public readonly string _connectionString; //Variável de connection string a ser preenchida
        public readonly IMapper _mapper;
        public UsuarioRepository(string connectioString)
        {
            _connectionString = connectioString;
        }
        public void Adicionar(Usuario usuario)
        {
            using var connection = new SQLiteConnection(_connectionString);
            connection.Insert<Usuario>(usuario);
        }
        public void Remover(int id)
        {
            using var connection = new SQLiteConnection(_connectionString);
            Usuario usuario = BuscarPorId(id);
            connection.Delete<Usuario>(usuario);
        }
        public void Editar(Usuario usuario)
        {
            using var connection = new SQLiteConnection(_connectionString);
            connection.Update<Usuario>(usuario);
        }
        public List<Usuario> Listar()
        {
            using var connection = new SQLiteConnection(_connectionString);
            return connection.GetAll<Usuario>().ToList();
        }
        public Usuario BuscarPorId(int id)
        {
            using var connection = new SQLiteConnection(_connectionString);
            return connection.Get<Usuario>(id);
        }
    }
}
