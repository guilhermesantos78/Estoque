using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Estoque.Entidades
{
    [Table("Produtos")]
    public class Produto
    {
        // [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Compo Obrigatório 'Nome' não preenchido")]
        [MinLength(2, ErrorMessage = "Quantidade de caracteres abaixo da mínima")]
        [MaxLength(100, ErrorMessage = "Quantidade de caracteres acima da máxima")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Compo Obrigatório 'Preco' não preenchido")]
        [Range(1, 10000, ErrorMessage = "Preço Inválido")]
        public double Preco { get; set; }
        [Required(ErrorMessage = "Compo Obrigatório 'Descricao' não preenchido")]
        [MinLength(2, ErrorMessage = "Quantidade de caracteres abaixo da mínima")]
        [MaxLength(300, ErrorMessage = "Quantidade de caracteres acima da máxima")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Compo Obrigatório 'QuantidadeEmEstoque' não preenchido")]
        [Range(1, 10000, ErrorMessage = "QuantidadeEmEstoque Inválido")]
        public int QuantidadeEmEstoque { get; set; }
        [Required(ErrorMessage = "Compo Obrigatório 'FornecedorId' não preenchido")]
        [Range(1, 10000, ErrorMessage = "FornecedorId Inválido")]
        public int FornecedorId { get; set; }

    }
}
