using Dapper.Contrib.Extensions;

namespace Estoque.Entidades
{
    [Table("Fornecedores")]
    public class Fornecedor
    {
        // [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Contato { get; set; }
        public string Endereco { get; set; }
        public string CNPJ { get; set; }
        public int ProdutoId { get; set; }
        public int UsuarioId { get; set; }

    }
}
