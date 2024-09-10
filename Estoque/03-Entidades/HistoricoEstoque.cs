using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Entidades
{
    public class HistoricoEstoque
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public DateTime Data { get; set; }
        public int QuantidadeAlterada { get; set; }
        public string TipoAlteracao { get; set; } // Entrada, Saída, Ajuste
        public string Descricao { get; set; }
    }

}
