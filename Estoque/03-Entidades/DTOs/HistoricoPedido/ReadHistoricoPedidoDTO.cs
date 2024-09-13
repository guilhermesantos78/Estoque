using System.ComponentModel.DataAnnotations;

namespace Estoque.Entidades
{
    public class ReadHistoricoPedidoDTO
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
