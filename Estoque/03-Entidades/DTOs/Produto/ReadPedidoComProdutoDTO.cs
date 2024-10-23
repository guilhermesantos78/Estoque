using Estoque.Entidades;

namespace Estoque.Services
{
    public class ReadPedidoComProdutoDTO
    {
        public DateTime DataPedido { get; set; }
        public DateTime DataEntrega { get; set; }
        public int QuantidadeSolicitada { get; set; }
        public string TipoAlteracao { get; set; } // Entrada, Saída, Ajuste
        public string NomeProduto { get; set; }
        public int ProdutoId { get; set; }
        public int UsuarioId { get; set; }
        public Produto produto { get; set; }
    }
}
