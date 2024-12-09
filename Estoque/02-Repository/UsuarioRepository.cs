using Core.Entidades;
using Dapper;
using Dapper.Contrib.Extensions;
using Estoque.Entidades;
using Estoque.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SQLite;

namespace TrabalhoFinal.Repository;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly string ConnectionString;
    public UsuarioRepository(IConfiguration configuration)
    {
        ConnectionString = configuration.GetConnectionString("DefaultConnection");
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

    public ActionResult<IEnumerable<Usuario>> GetUsuarioByEmpresaId(int EmpresaId)
    {
        using var connection = new SQLiteConnection(ConnectionString); // conexão com SQLite
        connection.Open();

        // Usando Dapper puro para realizar a consulta filtrada por EmpresaId
        string query = "SELECT * FROM Usuarios WHERE EmpresaId = @EmpresaId";
        List<Usuario> Usuarios = connection.Query<Usuario>(query, new { EmpresaId = EmpresaId }).ToList();

        if (Usuarios == null || !Usuarios.Any())
        {
            return NotFound("Nenhum produto encontrado para o usuário especificado."); // Utilizar NotFound ao invés de NotFoundResult
        }

        return Ok(Usuarios); // Retorna a lista de produtos encontrados
    }

    private ActionResult<IEnumerable<Usuario>> NotFound(string mensagem)
    {
        // Aqui você pode retornar uma resposta personalizada para o NotFound
        return new ContentResult
        {
            Content = mensagem,
            ContentType = "text/plain",
            StatusCode = 404
        };
    }

    private ActionResult<IEnumerable<Usuario>> Ok(List<Usuario> Usuarios)
    {
        // Aqui você pode retornar a lista de produtos em um formato apropriado
        return new JsonResult(Usuarios)
        {
            StatusCode = 200 // OK status
        };
    }

}