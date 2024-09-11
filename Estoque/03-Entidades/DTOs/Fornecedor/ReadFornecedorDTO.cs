using Estoque.Entidades;

namespace Estoque.Services
{
    public class ReadFornecedorDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Contato { get; set; }
        public string Endereco { get; set; }
        public string CNPJ { get; set; }
        public int FornecedorId { get; set; }
        public Fornecedor fornecedor { get; set; }
    }
}
