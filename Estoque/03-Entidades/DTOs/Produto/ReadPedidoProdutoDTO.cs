using Estoque.Entidades;

namespace Estoque.Services
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
