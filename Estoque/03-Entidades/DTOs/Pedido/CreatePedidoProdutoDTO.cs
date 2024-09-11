using Estoque.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque._03_Entidades.DTOs.Pedido
{
    public class ReadPedidoProdutoDTO
    {
        public DateTime DataPedido { get; set; }
        public DateTime DataEntrega { get; set; }
        public int QuantidadeSolicitada { get; set; }
        public string NomeProduto { get; set; }
        public int ProdutoId { get; set; }
        public Produto produto { get; set; }
    }
}
