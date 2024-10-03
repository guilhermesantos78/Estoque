using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Estoque.Entidades
{
    [Table("Pedidos")]
    public class Pedido
    {
        [Key]
        public int Id { get; set; }
        public DateTime DataPedido { get; set; }
        public DateTime DataEntrega { get; set; }
        public int QuantidadeSolicitada { get; set; }
        public string TipoAlteracao { get; set; } // Entrada, Saída, Ajuste
        public string NomeProduto { get; set; }
        public int ProdutoId { get; set; }

    }
}
