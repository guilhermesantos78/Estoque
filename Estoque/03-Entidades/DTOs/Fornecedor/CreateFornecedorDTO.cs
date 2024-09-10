using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Entidades.DTOs.Fornecedor
{
    public class CreateFornecedorDTO
    {
        public string Nome { get; set; }
        public string Contato { get; set; }
        public string Endereco { get; set; }
        public string CNPJ { get; set; }
    }
}
