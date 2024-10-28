using Estoque.Entidades;

namespace Estoque.Services
{
    public interface IPedidoService
    {
        public void Adicionar(Pedido pedido);
        public void Remover(int id);
        public void Editar(Pedido editPedido);
        public List<Pedido> Listar();
        public List<ReadPedidoComProdutoDTO> VisualizarPedidoInfoProduto();
        public Pedido BuscarPorId(int id);
    }
}
