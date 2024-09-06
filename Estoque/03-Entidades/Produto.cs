using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Estoque
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public string Descricao { get; set; }
        public int QuantidadeEmEstoque { get; set; }
        public int FornecedorId { get; set; }

        //[JsonIgnore]
        //public virtual Fornecedor? fornecedor { get; set; } = new Fornecedor();

    }
}
