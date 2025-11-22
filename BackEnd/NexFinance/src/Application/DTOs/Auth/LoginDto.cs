using System.ComponentModel.DataAnnotations;

namespace NexFinance.src.Application.DTOs {
    public class LoginDto {

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve ter exatamente 11 caracteres.")]
        [RegularExpression("^[0-9]{11}$", ErrorMessage = "O CPF deve conter apenas números.")]
        public string Cpf { get; set; } = string.Empty;

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "A senha deve ter entre 8 e 100 caracteres.")]
        public string Senha { get; set; } = string.Empty;
    }
}