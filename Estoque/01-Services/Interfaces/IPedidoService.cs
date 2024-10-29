using Estoque.Entidades;

namespace Estoque.Services
{
    public interface IPedidoService
    {
        void Adicionar(Pedido pedido);
        void Remover(int id);
        void Editar(Pedido editPedido);
        List<Pedido> Listar();
        List<ReadPedidoComProdutoDTO> VisualizarPedidoInfoProduto();
        Pedido BuscarPorId(int id);
    }
}
