using Dapper;
using Dapper.Contrib.Extensions;
using Estoque.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Data.SQLite;

namespace Estoque.Repository
{
    public class EmpresaRepository : IEmpresaRepository
    {
        public readonly string _connectionString; //Variável de connection string a ser preenchida

        public EmpresaRepository(IConfiguration configuration) //Responsavel por preencher a connection string
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
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

        public ActionResult<IEnumerable<Empresa>> GetEmpresaByEmpresaId(int EmpresaId)
        {
            using var connection = new SQLiteConnection(_connectionString); // conexão com SQLite
            connection.Open();

            // Usando Dapper puro para realizar a consulta filtrada por EmpresaId
            string query = "SELECT * FROM Empresas WHERE EmpresaId = @EmpresaId";
            List<Empresa> Empresas = connection.Query<Empresa>(query, new { EmpresaId = EmpresaId }).ToList();

            if (Empresas == null || !Empresas.Any())
            {
                return NotFound("Nenhum produto encontrado para o usuário especificado."); // Utilizar NotFound ao invés de NotFoundResult
            }

            return Ok(Empresas); // Retorna a lista de produtos encontrados
        }

        private ActionResult<IEnumerable<Empresa>> NotFound(string mensagem)
        {
            // Aqui você pode retornar uma resposta personalizada para o NotFound
            return new ContentResult
            {
                Content = mensagem,
                ContentType = "text/plain",
                StatusCode = 404
            };
        }

        private ActionResult<IEnumerable<Empresa>> Ok(List<Empresa> Empresas)
        {
            // Aqui você pode retornar a lista de produtos em um formato apropriado
            return new JsonResult(Empresas)
            {
                StatusCode = 200 // OK status
            };
        }



    }
}
