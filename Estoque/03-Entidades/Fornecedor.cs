using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Entidades
{
    [Table("Fornecedores")]
    public class Fornecedor
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Contato { get; set; }
        public string Endereco { get; set; }
        public string CNPJ { get; set; }

    }
}
