using Estoque.Repository;
using Estoque.Entidades;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Estoque.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository repository;

        public PedidoService(IMapper mapper, IPedidoRepository pedidoRepository)
        {
            repository = pedidoRepository;
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

        public ActionResult<IEnumerable<Pedido>> GetPedidosByEmpresaId(int EmpresaId)
        {
            return repository.GetPedidosByEmpresaId(EmpresaId);
        }

    }
}
