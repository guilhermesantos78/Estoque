namespace Estoque.Repository
{
    public class ProdutoScript
    {
        public static string InsertProduto()
        {
            string commandINSERTProduto = @"
                INSERT INTO Produtos(Nome, Preco, Descricao, QuantidadeEmEstoque , FornecedorId)
                VALUES (@Nome, @Preco, @Descricao , @QuantidadeEmEstoque, @FornecedorId)";

            return commandINSERTProduto;
        }
    }
}
