using NexFinance.Domain.Enums;

namespace NexFinance.src.Application.DTOs {
    public record LancamentoDto(int Id, int UsuarioId, int CategoriaId, int ContaId, string Tipo, decimal Valor, DateTime Data, string? Descricao, DateTime DataCriacao);

    public record CreateLancamentoDto(int UsuarioId, int CategoriaId, int ContaId, string Tipo, decimal Valor, DateTime Data, string? Descricao);

    public record UpdateLancamentoDto(decimal Valor, DateTime Data, string? Descricao, int CategoriaId, int ContaId, string Tipo);

}
