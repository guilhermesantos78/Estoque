namespace Estoque.Repository
{
    public class ClienteScript
    {
        public static string InsertCliente()
        {
            string commandINSERTFornecedor = @"
                INSERT INTO Clientes(Nome, Contato, Endereco, CNPJ)
                VALUES(@Nome, @Contato, @Endereco, @CNPJ)";

            return commandINSERTFornecedor;
        }
    }
}
