using Dapper;
using Dapper.Contrib.Extensions;
using Estoque.Repository.Data.Script;
using Estoque.Entidades;
using System.Data.SQLite;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace Estoque.Repository
{
    public class FornecedorRepository : IFornecedorRepository
    {
        public readonly string _connectionString; //Variável de connection string a ser preenchida

        public FornecedorRepository(IConfiguration configuration) //Responsavel por preencher a connection string
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public void Adicionar(Fornecedor fornecedor)
        {
            using var connection = new SQLiteConnection(_connectionString);

            connection.Execute(FornecedorScript.InsertFornecedor(), fornecedor);
        }

        public void Remover(int id)
        {
            using var connection = new SQLiteConnection(_connectionString); // conexao
            Fornecedor novoFornecedor = BuscarPorId(id);

            connection.Delete<Fornecedor>(novoFornecedor);
        }

        public void Editar(Fornecedor editFornecedor)
        {
            using var connection = new SQLiteConnection(_connectionString); // conexao

            connection.Update<Fornecedor>(editFornecedor);
        }

        public List<Fornecedor> Listar()
        {
            using var connection = new SQLiteConnection(_connectionString);// conexao

            return connection.GetAll<Fornecedor>().ToList();
        }

        public Fornecedor BuscarPorId(int id)
        {
            using var connection = new SQLiteConnection(_connectionString);

            return connection.Get<Fornecedor>(id);
        }

        public ReadFornecedorDTO BuscarFornecedorNamePorId(int id)
        {
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();

            var query = "SELECT Id, Nome FROM Fornecedores WHERE Id = @Id";

            var fornecedor = connection.QuerySingleOrDefault<ReadFornecedorDTO>(query, new { Id = id });

            return fornecedor;
        }

        public ActionResult<IEnumerable<Fornecedor>> GetFornecedorByEmpresaId(int EmpresaId)
        {
            using var connection = new SQLiteConnection(_connectionString); // conexão com SQLite
            connection.Open();

            // Usando Dapper puro para realizar a consulta filtrada por EmpresaId
            string query = "SELECT * FROM Fornecedores WHERE EmpresaId = @EmpresaId";
            List<Fornecedor> Fornecedores = connection.Query<Fornecedor>(query, new { EmpresaId = EmpresaId }).ToList();

            if (Fornecedores == null || !Fornecedores.Any())
            {
                return NotFound("Nenhum produto encontrado para o usuário especificado."); // Utilizar NotFound ao invés de NotFoundResult
            }

            return Ok(Fornecedores); // Retorna a lista de produtos encontrados
        }

        private ActionResult<IEnumerable<Fornecedor>> NotFound(string mensagem)
        {
            // Aqui você pode retornar uma resposta personalizada para o NotFound
            return new ContentResult
            {
                Content = mensagem,
                ContentType = "text/plain",
                StatusCode = 404
            };
        }

        private ActionResult<IEnumerable<Fornecedor>> Ok(List<Fornecedor> Fornecedores)
        {
            // Aqui você pode retornar a lista de produtos em um formato apropriado
            return new JsonResult(Fornecedores)
            {
                StatusCode = 200 // OK status
            };
        }


    }
}
