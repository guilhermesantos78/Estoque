using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque._03_Entidades
{
    public class Funcionario
    {
        public int IdFun { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNasc { get; set; }
        public string Endereco { get; set; }
        public int Telefone { get; set; }
        public string Email { get; set; }
    }
}
