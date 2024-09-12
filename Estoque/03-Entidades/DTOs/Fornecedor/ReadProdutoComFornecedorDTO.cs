using Estoque.Entidades;
using System.ComponentModel.DataAnnotations;

namespace Estoque.Services
{
    public class ReadProdutoComFornecedorDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public string Descricao { get; set; }
        public int QuantidadeEmEstoque { get; set; }
        public int FornecedorId { get; set; }
        public Fornecedor fornecedor { get; set; }
    }
}
