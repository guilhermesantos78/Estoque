namespace Estoque.Repository
{
    public class FornecedorScript
    {
        public static string InsertFornecedor()
        {
            string commandINSERTFornecedor = @"
                INSERT INTO Fornecedores(Nome, Contato, Endereco, CNPJ)
                VALUES(@Nome, @Contato, @Endereco, @CNPJ)";

            return commandINSERTFornecedor;
        }
    }
}
