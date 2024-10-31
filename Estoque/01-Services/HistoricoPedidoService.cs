using AutoMapper;
using Estoque.Repository;

namespace Estoque.Services
{
    public class HistoricoPedidoService : IHistoricoPedidoService
    {
        public IHistoricoPedidoRepository repository { get; set; }

        public HistoricoPedidoService(IMapper mapper ,IHistoricoPedidoRepository historicoPedidoRepository)
        {
            repository = historicoPedidoRepository;
        }

        public List<ReadPedidoComProdutoDTO> VisualizarHistoricoPedidos()
        {
            return repository.VisualizarHistoricoPedidos();
        }
    }
}
