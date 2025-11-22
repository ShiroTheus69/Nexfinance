namespace NexFinance.src.Application.DTOs.Auth {
    public class LoginResponseDto {
        public string Token { get; set; } = string.Empty;
        public DateTime ExpiraEm { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}

