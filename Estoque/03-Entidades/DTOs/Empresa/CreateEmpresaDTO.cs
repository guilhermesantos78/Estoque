﻿using System.ComponentModel.DataAnnotations;

namespace Estoque.Services
{
    public class CreateEmpresaDTO
    {
        [Required(ErrorMessage = "Compo Obrigatório 'Nome' não preenchido")]
        [MinLength(2, ErrorMessage = "Quantidade de caracteres abaixo da mínima")]
        [MaxLength(100, ErrorMessage = "Quantidade de caracteres acima da máxima")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Compo Obrigatório 'Contato' não preenchido")]
        [MinLength(2, ErrorMessage = "Quantidade de caracteres abaixo da mínima")]
        [MaxLength(300, ErrorMessage = "Quantidade de caracteres acima da máxima")]
        public string Contato { get; set; }
        [Required(ErrorMessage = "Compo Obrigatório 'Endereco' não preenchido")]
        [MinLength(2, ErrorMessage = "Quantidade de caracteres abaixo da mínima")]
        [MaxLength(50, ErrorMessage = "Quantidade de caracteres acima da máxima")]
        public string Endereco { get; set; }
        [Required(ErrorMessage = "Compo Obrigatório 'CNPJ' não preenchido")]
        [MinLength(2, ErrorMessage = "Quantidade de caracteres abaixo da mínima")]
        [MaxLength(14, ErrorMessage = "Quantidade de caracteres acima da máxima")]
        public string CNPJ { get; set; }

    }
}
