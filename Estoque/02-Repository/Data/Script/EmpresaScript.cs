namespace Estoque.Repository
{
    public class EmpresaScript
    {
        public static string InsertEmpresa()
        {
            string commandINSERTFornecedor = @"
                INSERT INTO Empresas(Nome, Contato, Endereco, CNPJ)
                VALUES(@Nome, @Contato, @Endereco, @CNPJ)";

            return commandINSERTFornecedor;
        }
    }
}
