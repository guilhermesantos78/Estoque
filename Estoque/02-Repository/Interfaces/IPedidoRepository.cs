
using Estoque.Entidades;
using Estoque.Services;

namespace Estoque.Repository
{
    public interface IPedidoRepository
    {
        public void Adicionar(Pedido pedido);
        public void Remover(int id);
        public void Editar(Pedido editPedido);
        public List<Pedido> Listar();
        public List<ReadPedidoComProdutoDTO> ListarInfoProduto();
        public Pedido BuscarPorId(int id);
    }
}
