using System.ComponentModel.DataAnnotations;

namespace Estoque.Entidades.DTOs.FuncionarioLog
{
    public class CreateFuncionarioLogDTO
    {
        [Required(ErrorMessage = "Compo Obrigatório 'Nome' não preenchido")]
        [MinLength(2, ErrorMessage = "Quantidade de caracteres abaixo da mínima")]
        [MaxLength(50, ErrorMessage = "Quantidade de caracteres acima da máxima")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Compo Obrigatório 'Email' não preenchido")]
        [MinLength(2, ErrorMessage = "Quantidade de caracteres abaixo da mínima")]
        [MaxLength(50, ErrorMessage = "Quantidade de caracteres acima da máxima")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Compo Obrigatório 'Senha' não preenchido")]
        [MinLength(2, ErrorMessage = "Quantidade de caracteres abaixo da mínima")]
        [MaxLength(30, ErrorMessage = "Quantidade de caracteres acima da máxima")]
        public string Senha { get; set; }
    }
}
