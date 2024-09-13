using System.ComponentModel.DataAnnotations;
using Estoque.Entidades;

namespace Estoque.Entidades.DTOs.HistoricoEstoque
{
    public class ReadHistoricoEstoqueDTO
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public int QuantidadeAlterada { get; set; }
        public string TipoAlteracao { get; set; }
        public string Descricao { get; set; }
        public int ProdutoId { get; set; }
        public Produto produto { get; set; }

    }
}
