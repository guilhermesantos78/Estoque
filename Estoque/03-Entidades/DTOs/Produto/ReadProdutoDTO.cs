using Estoque.Entidades;

namespace Estoque.Entidades
{
    public class ReadProdutoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public string Descricao { get; set; }
        public int QuantidadeEmEstoque { get; set; }
        public ReadFornecedorDTO fornecedorname { get; set; }
        public int FornecedorId { get; set; }
        public int EmpresaId { get; set; }

    }
}
