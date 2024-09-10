using Estoque._02_Repository;
using Estoque._03_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque._01_Services
{
    public class PedidoService
    {
        public PedidoRepository repository { get; set; }

        public PedidoService(string ConnectionString)
        {
            repository = new PedidoRepository(ConnectionString);
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

        public Pedido BuscarPedidoPorId(int id)
        {
            return repository.BuscarPedidoPorId(id);
        }
    }
}
