using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Repository.Data.Script
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
