using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Entidades
{
    public class Pedido
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Compo Obrigatório 'DataPedido' não preenchido")]
        public DateOnly DataPedido { get; set; }
        [Required(ErrorMessage = "Compo Obrigatório 'DataEntrega' não preenchido")]
        public DateOnly DataEntrega { get; set; }
        [Required(ErrorMessage = "Compo Obrigatório 'QuantidadeSolicitada' não preenchido")]
        public int QuantidadeSolicitada { get; set; }
        [Required(ErrorMessage = "Compo Obrigatório 'NomeProduto' não preenchido")]
        [MinLength(2, ErrorMessage = "Quantidade de caracteres abaixo da mínima")]
        [MaxLength(100, ErrorMessage = "Quantidade de caracteres acima da máxima")]
        public string NomeProduto { get; set; }
        [Required(ErrorMessage = "Compo Obrigatório 'ProdutoId' não preenchido")]
        [Range(1, 10000, ErrorMessage = "ProdutoId Inválido")]
        public int ProdutoId { get; set; }

    }
}
