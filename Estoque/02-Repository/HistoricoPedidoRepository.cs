using Dapper;
using Dapper.Contrib.Extensions;
using Estoque.Entidades;
using System.Data.SQLite;
using Estoque.Repository.Data.Script;
using Estoque.Services;
using AutoMapper;

namespace Estoque._02_Repository
{
    public class HistoricoPedidoRepository
    {
        private readonly string _connectionString;
        private readonly IMapper _mapper;

        public HistoricoPedidoRepository(string connectionString, IMapper mapper)
        {
            _connectionString = connectionString;
            _mapper = mapper;
        }

        public List<ReadPedidoComProdutoDTO> ListarHistorico()
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
    }
}
