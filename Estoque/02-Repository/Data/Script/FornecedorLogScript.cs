using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Repository.Data.Script
{
    public class FornecedorLogScript
    {
        public static string InsertFornecedorLog()
        {
            string commandINSERTFornecedorLog = @"
                INSERT INTO FuncionariosLogin (Nome, Email, Senha)
                VALUES (@Nome, @Email, @Senha)";

            return commandINSERTFornecedorLog;
        }
    }
}
