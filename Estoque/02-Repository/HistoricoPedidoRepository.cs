using Dapper;
using Dapper.Contrib.Extensions;
using Estoque.Entidades;
using System.Data.SQLite;
using Estoque.Repository.Data.Script;
using Estoque.Services;
using Estoque.Entidades.DTOs.HistoricoEstoque;

namespace Estoque._02_Repository
{
    public class HistoricoPedidoRepository
    {
        private readonly string _connectionString;

        public HistoricoPedidoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Adicionar(HistoricoPedidos HistoricoPedido)
        {
            using var connection = new SQLiteConnection(_connectionString);

            connection.Execute(HistoricoPedidoScript.InsertHistoricoPedido(), HistoricoPedido);
        }

        public List<ReadHistoricoPedidoDTO> ListarInfoProduto()
        {
            using var connection = new SQLiteConnection(_connectionString);
            List<Produto> pedidos = connection.GetAll<Produto>().ToList();
            List<ReadHistoricoPedidoDTO> lista = _mapper.Map<List<ReadHistoricoPedidoDTO>>(pedidos);

            foreach (ReadHistoricoPedidoDTO item in lista)
            {
                item.produto = connection.Get<Produto>(item.ProdutoId);
            }

            return lista;
        }
    }
}
