using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Repository.Data.Script
{
    public class ProdutoScript
    {
        public static string InsertProduto()
        {
            string commandINSERTProduto = @"
                INSERT INTO Produtos(Nome, Preco, Descricao, QuantidadeEmEstoque , FornecedorId, UsuarioId)
                VALUES (@Nome, @Preco, @Descricao , @QuantidadeEmEstoque, @FornecedorId, @UsuarioId)";

            return commandINSERTProduto;
        }
    }
}
