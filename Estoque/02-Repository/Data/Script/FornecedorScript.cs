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
                INSERT INTO Fornecedores(Nome, Contato, Endereco, CNPJ, ProdutoId, EmpresaId)
                VALUES(@Nome, @Contato, @Endereco, @CNPJ, @ProdutoId, @EmpresaId)";

            return commandINSERTFornecedor;
        }
    }
}
