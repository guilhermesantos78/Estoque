using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Repository
{
    class UsuarioScript
    {
        public static string InsertUsuario()
        {
            string commandINSERTFornecedor = @"
                INSERT INTO Usuarios(Nome, Username, TipoUsuario, Senha, Email, EmpresaId)
                VALUES(@Nome, @Username, @TipoUsuario, @Senha, @Email, @EmpresaId)";

            return commandINSERTFornecedor;
        }
    } 
}
