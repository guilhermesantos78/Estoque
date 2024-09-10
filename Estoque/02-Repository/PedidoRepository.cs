using Dapper;
using Dapper.Contrib.Extensions;
using Estoque.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Repository
{
    public class PedidoRepository
    {
        private readonly string _connectionString;

        public PedidoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Adicionar(Pedido pedido)
        {
            using var connection = new SQLiteConnection(_connectionString);

            string commandInsert = @"INSERT INTO Pedidos (DataPedido, DataEntrega, QuantidadeSolicitada, ProdutoId)
                                    VALUES (@DataPedido, @DataEntrega, @QuantidadeSolicitada, @ProdutoId)";

            connection.Execute(commandInsert, pedido);
        }

        public void Remover(int id)
        {
            using var connection = new SQLiteConnection(_connectionString); // conexao
            Pedido novoPedido = BuscarPedidoPorId(id);
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

        public Pedido BuscarPedidoPorId(int id)
        {
            using var connection = new SQLiteConnection(_connectionString);
            return connection.Get<Pedido>(id);
        }
    }
}
