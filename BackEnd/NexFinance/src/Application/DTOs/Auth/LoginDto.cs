using System.ComponentModel.DataAnnotations;

namespace NexFinance.src.Application.DTOs {
    public class LoginDto {
        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "Formato de e-mail inválido.")]
        [StringLength(150, ErrorMessage = "O e-mail deve ter no máximo 150 caracteres.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "A senha deve ter entre 8 e 100 caracteres.")]
        public string Senha { get; set; } = string.Empty;
    }
}
