using AutoMapper;
using Estoque.Repository;

namespace Estoque.Services
{
    public class HistoricoPedidoService : IHistoricoPedidoService
    {
        public IHistoricoPedidoRepository repository { get; set; }

        public HistoricoPedidoService(IMapper mapper ,string ConnectionString)
        {
            repository = new HistoricoPedidoRepository(ConnectionString, mapper);
        }

        public List<ReadPedidoComProdutoDTO> VisualizarHistoricoPedidos()
        {
            return repository.VisualizarHistoricoPedidos();
        }
    }
}
