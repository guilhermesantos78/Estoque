
using Estoque.Services;

namespace Estoque.Repository
{
    public interface IHistoricoPedidoRepository
    {
        List<ReadPedidoComProdutoDTO> VisualizarHistoricoPedidos();
    }
}
