using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public string Descricao { get; set; }
        public int QuantidadeEmEstoque { get; set; }
        public int FornecedorId { get; set; }
        public virtual Fornecedor fornecedor { get; set; }

    }
}
