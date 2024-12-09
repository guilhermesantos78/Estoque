using Dapper;
using Dapper.Contrib.Extensions;
using Estoque.Repository.Data.Script;
using Estoque.Entidades;
using System.Data.SQLite;
using AutoMapper;
using Estoque.Services;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace Estoque.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly string _connectionString;
        private readonly IMapper _mapper;

        public PedidoRepository(IConfiguration configuration, IMapper mapper)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _mapper = mapper;
        }

        public void Adicionar(Pedido pedido)
        {
            using var connection = new SQLiteConnection(_connectionString);

            connection.Execute(PedidoScript.InsertPedido(), pedido);
        }

        public void Remover(int id)
        {
            using var connection = new SQLiteConnection(_connectionString); // conexao
            Pedido novoPedido = BuscarPorId(id);

            connection.Delete<Pedido>(novoPedido);
        }

        public void Editar(Pedido editPedido)
        {
            using var connection = new SQLiteConnection(_connectionString); // conexao

            connection.Update<Pedido>(editPedido);
        }

        public List<Pedido> Listar()
        {
            using var connection = new SQLiteConnection(_connectionString);

            return connection.GetAll<Pedido>().ToList();
        }

        public List<ReadPedidoComProdutoDTO> ListarInfoProduto()
        {
            using var connection = new SQLiteConnection(_connectionString);
            List<Pedido> pedidos = connection.GetAll<Pedido>().ToList();
            List<ReadPedidoComProdutoDTO> lista = _mapper.Map<List<ReadPedidoComProdutoDTO>>(pedidos);

            foreach (ReadPedidoComProdutoDTO item in lista)
            {
                item.produto = connection.Get<Produto>(item.ProdutoId); 
            }

            return lista;
        }

        public Pedido BuscarPorId(int id)
        {
            using var connection = new SQLiteConnection(_connectionString);

            return connection.Get<Pedido>(id);
        }

        public ActionResult<IEnumerable<Pedido>> GetPedidosByEmpresaId(int EmpresaId)
        {
            using var connection = new SQLiteConnection(_connectionString); // conexão com SQLite
            connection.Open();

            // Usando Dapper puro para realizar a consulta filtrada por EmpresaId
            string query = "SELECT * FROM Pedidos WHERE EmpresaId = @EmpresaId";
            List<Pedido> Pedidos = connection.Query<Pedido>(query, new { EmpresaId = EmpresaId }).ToList();

            if (Pedidos == null || !Pedidos.Any())
            {
                return NotFound("Nenhum produto encontrado para o usuário especificado."); // Utilizar NotFound ao invés de NotFoundResult
            }

            return Ok(Pedidos); // Retorna a lista de produtos encontrados
        }

        private ActionResult<IEnumerable<Pedido>> NotFound(string mensagem)
        {
            // Aqui você pode retornar uma resposta personalizada para o NotFound
            return new ContentResult
            {
                Content = mensagem,
                ContentType = "text/plain",
                StatusCode = 404
            };
        }

        private ActionResult<IEnumerable<Pedido>> Ok(List<Pedido> Pedidos)
        {
            // Aqui você pode retornar a lista de produtos em um formato apropriado
            return new JsonResult(Pedidos)
            {
                StatusCode = 200 // OK status
            };
        }


    }
}
