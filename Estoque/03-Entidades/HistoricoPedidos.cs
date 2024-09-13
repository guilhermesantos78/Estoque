using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Entidades
{
    public class HistoricoPedidos
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório 'ProdutoId' não preenchido")]
        [Range(1, 10000, ErrorMessage = "ProdutoId Inválido")]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório 'Produto' não preenchido")]
        public Produto Produto { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório 'Data' não preenchido")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório 'QuantidadeAlterada' não preenchido")]
        [Range(1, 10000, ErrorMessage = "QuantidadeAlterada Inválida")]
        public int QuantidadeAlterada { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório 'TipoAlteracao' não preenchido")]
        [MinLength(2, ErrorMessage = "Quantidade de caracteres abaixo da mínima")]
        [MaxLength(100, ErrorMessage = "Quantidade de caracteres acima da máxima")]
        public string TipoAlteracao { get; set; } // Entrada, Saída, Ajuste

        [Required(ErrorMessage = "Campo Obrigatório 'Descricao' não preenchido")]
        [MinLength(2, ErrorMessage = "Quantidade de caracteres abaixo da mínima")]
        [MaxLength(300, ErrorMessage = "Quantidade de caracteres acima da máxima")]
    }
}
