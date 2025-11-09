namespace NexFinance.src.Application.DTOs {
    public record UsuarioDto(int Id, string Nome, string Cpf, string Email, int? Idade, DateTime DtCriacao);

    public record CreateUsuarioDto(string Nome, string Cpf, string Email, string SenhaPlain, int? Idade);

    public record UpdateUsuarioDto(string Nome, int? Idade);

}
