using Dapper.Contrib.Extensions;
using Estoque.Entidades;
using System.Data.SQLite;
using Estoque.Services;
using AutoMapper;
using Estoque.Repository;
using Microsoft.Extensions.Configuration;

namespace Estoque.Repository
{
    public class HistoricoPedidoRepository : IHistoricoPedidoRepository
    {
        private readonly string _connectionString;
        private readonly IMapper _mapper;

        public HistoricoPedidoRepository(IConfiguration configuration, IMapper mapper)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _mapper = mapper;
        }

        public List<ReadPedidoComProdutoDTO> VisualizarHistoricoPedidos()
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
