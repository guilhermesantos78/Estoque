using Estoque.Repository;
using Estoque.Entidades;
using AutoMapper;

namespace Estoque.Services
{
    public class PedidoService : IPedidoService
    {
        public IPedidoRepository repository { get; set; }

        public PedidoService(IMapper mapper, string ConnectionString)
        {
            repository = new PedidoRepository(ConnectionString, mapper);
        }

        public void Adicionar(Pedido pedido)
        {
            repository.Adicionar(pedido);
        }

        public void Editar(Pedido pedidoEdit)
        {
            repository.Editar(pedidoEdit);
        }

        public void Remover(int id)
        {
            repository.Remover(id);
        }

        public List<Pedido> Listar()
        {
            return repository.Listar();
        }

        public List<ReadPedidoComProdutoDTO> VisualizarPedidoInfoProduto()
        {
            return repository.ListarInfoProduto();
        }

        public Pedido BuscarPorId(int id)
        {
            return repository.BuscarPorId(id);
        }

    }
}
