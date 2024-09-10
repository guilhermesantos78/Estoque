using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Entidades
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime DataPedido { get; set; }
        public DateTime DataEntrega { get; set; }
        public int QuantidadeSolicitada { get; set; }
        public string NomeProduto { get; set; }
        public int ProdutoId { get; set; }
        public void SetNomeProduto(string nomeProduto)
        {
            NomeProduto = nomeProduto;
        }
    }
}
