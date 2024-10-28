using Dapper;
using Dapper.Contrib.Extensions;
using Estoque.Repository.Data.Script;
using Estoque.Entidades;
using System.Data.SQLite;
using AutoMapper;
using Estoque.Services;

namespace Estoque.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly string _connectionString;
        private readonly IMapper _mapper;

        public PedidoRepository(string connectionString, IMapper mapper)
        {
            _connectionString = connectionString;
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
    }
}
