using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Entidades.DTOs.Pedido
{
    public class CreatePedidoDTO
    {
        public DateTime DataPedido { get; set; }
        public DateTime DataEntrega { get; set; }
        public int QuantidadeSolicitada { get; set; }
        public string NomeProduto { get; set; }
        public int ProdutoId { get; set; }

    }
}
