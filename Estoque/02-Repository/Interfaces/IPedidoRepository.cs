
using Estoque.Entidades;
using Estoque.Services;
using Microsoft.AspNetCore.Mvc;

namespace Estoque.Repository
{
    public interface IPedidoRepository
    {
        void Adicionar(Pedido pedido);
        void Remover(int id);
        void Editar(Pedido editPedido);
        List<Pedido> Listar();
        List<ReadPedidoComProdutoDTO> ListarInfoProduto();
        Pedido BuscarPorId(int id);
        ActionResult<IEnumerable<Pedido>> GetPedidosByEmpresaId(int EmpresaId);
    }
}
