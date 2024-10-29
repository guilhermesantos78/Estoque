
using Estoque.Services;

namespace Estoque.Repository
{
    public interface IHistoricoPedidoRepository
    {
        public List<ReadPedidoComProdutoDTO> VisualizarHistoricoPedidos();
    }
}
