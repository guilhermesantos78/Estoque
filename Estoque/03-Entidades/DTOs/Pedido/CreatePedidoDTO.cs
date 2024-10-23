using System.ComponentModel.DataAnnotations;

namespace Estoque.Entidades.DTOs.Pedido
{
    public class CreatePedidoDTO
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Compo Obrigatório 'DataPedido' não preenchido")]
        public DateTime DataPedido { get; set; }
        [Required(ErrorMessage = "Compo Obrigatório 'DataEntrega' não preenchido")]
        public DateTime DataEntrega { get; set; }
        [Required(ErrorMessage = "Compo Obrigatório 'QuantidadeSolicitada' não preenchido")]
        public int QuantidadeSolicitada { get; set; }
        [Required(ErrorMessage = "Compo Obrigatório 'NomeProduto' não preenchido")]
        [MinLength(2, ErrorMessage = "Quantidade de caracteres abaixo da mínima")]
        [MaxLength(100, ErrorMessage = "Quantidade de caracteres acima da máxima")]
        public string TipoAlteracao { get; set; } // Entrada, Saída, Ajuste
        public string NomeProduto { get; set; }
        [Required(ErrorMessage = "Compo Obrigatório 'ProdutoId' não preenchido")]
        [Range(1, 10000, ErrorMessage = "ProdutoId Inválido")]
        public int ProdutoId { get; set; }
        public int UsuarioId { get; set; }

        public CreatePedidoDTO()
        {
            DataPedido = DateTime.Now;
        }
    }
}
