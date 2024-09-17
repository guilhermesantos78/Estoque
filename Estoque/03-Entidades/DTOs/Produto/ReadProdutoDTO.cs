namespace Estoque.Entidades
{
    public class ReadProdutoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public string Descricao { get; set; }
        public int QuantidadeEmEstoque { get; set; }
        public Fornecedor fornecedor { get; set; }
        public int FornecedorId { get; set; }

    }
}
