namespace NexFinance.src.Application.DTOs {
    public record TransferenciaDto(int Id, int UsuarioId, int ContaOrigemId, int ContaDestinoId, decimal Valor, DateTime Data, string? Descricao, DateTime DataCriacao);

    public record CreateTransferenciaDto(int UsuarioId, int ContaOrigemId, int ContaDestinoId, decimal Valor, DateTime Data, string? Descricao);

    public record UpdateTransferenciaDto(decimal Valor, DateTime Data, string? Descricao);

}
