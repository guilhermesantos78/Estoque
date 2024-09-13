using Estoque._02_Repository;
using Estoque.Entidades;
using Estoque.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Services
{
    public class HistoricoPedidoService
    {
        public HistoricoPedidoRepository repository { get; set; }

        public HistoricoPedidoService(string ConnectionString)
        {
            repository = new HistoricoPedidoRepository(ConnectionString);
        }

        public void Adicionar(HistoricoPedidos historicopedidos)
        {
            repository.Adicionar(historicopedidos);
        }


        public List<HistoricoPedidos> Listar()
        {
            return repository.ListarInfoProduto();
        }
    }
}
