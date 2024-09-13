using System.ComponentModel.DataAnnotations;
using Estoque.Entidades;

namespace Estoque.Entidades.DTOs.HistoricoEstoque
{
    public class ReadHistoricoEstoqueDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Compo Obrigatório 'ProdutoId' não preenchido")]
        [Range(1, 10000, ErrorMessage = "ProdutoId Inválido")]
        public int ProdutoId { get; set; }
        [Required(ErrorMessage = "Compo Obrigatório 'Produto' não preenchido")]
        public DateTime Data { get; set; }
        [Required(ErrorMessage = "Compo Obrigatório 'QuantidadeAlterada' não preenchido")]
        [Range(1, 10000, ErrorMessage = "QuantidadeAlterada Inválida")]
        public int QuantidadeAlterada { get; set; }
        [Required(ErrorMessage = "Compo Obrigatório 'TipoAlteracao' não preenchido")]
        [MinLength(2, ErrorMessage = "Quantidade de caracteres abaixo da mínima")]
        [MaxLength(100, ErrorMessage = "Quantidade de caracteres acima da máxima")]
        public string TipoAlteracao { get; set; } // Entrada, Saída, Ajuste
        [Required(ErrorMessage = "Compo Obrigatório 'Descricao' não preenchido")]
        [MinLength(2, ErrorMessage = "Quantidade de caracteres abaixo da mínima")]
        [MaxLength(300, ErrorMessage = "Quantidade de caracteres acima da máxima")]
        public string Descricao { get; set; }
        public Produto produto { get; set; }
    }
}
