using Core.Entidades;
using Dapper;
using Dapper.Contrib.Extensions;
using Estoque.Repository;
using System.Data.SQLite;

namespace TrabalhoFinal.Repository;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly string ConnectionString;
    public UsuarioRepository(string connectioString)
    {
        ConnectionString = connectioString;
    }
    public void Adicionar(Usuario usuario)
    {
        using var connection = new SQLiteConnection(ConnectionString);

        connection.Execute(UsuarioScript.InsertUsuario(), usuario);
    }
    public void Remover(int id)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        Usuario usuario = BuscarPorId(id);
        connection.Delete<Usuario>(usuario);
    }
    public void Editar(Usuario usuario)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        connection.Update<Usuario>(usuario);
    }
    public List<Usuario> Listar()
    {
        using var connection = new SQLiteConnection(ConnectionString);
        return connection.GetAll<Usuario>().ToList();
    }
    public Usuario BuscarPorId(int id)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        return connection.Get<Usuario>(id);
    }
}