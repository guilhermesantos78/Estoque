using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque._03_Entidades
{
    [Table("FuncionariosLogin")]
    public class FuncionarioLog
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Role { get; set; } // Ex: Admin, Estoquista
    }
}
