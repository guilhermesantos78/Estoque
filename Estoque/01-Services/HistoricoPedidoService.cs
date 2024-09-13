using AutoMapper;
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

        public HistoricoPedidoService(IMapper mapper ,string ConnectionString)
        {
            repository = new HistoricoPedidoRepository(ConnectionString, mapper);
        }

        public void Adicionar(HistoricoPedidos historicopedidos)
        {
            repository.Adicionar(historicopedidos);
        }


        public List<ReadHistoricoPedidoDTO> Listar()
        {
            return repository.ListarInfoProduto();
        }
    }
}
