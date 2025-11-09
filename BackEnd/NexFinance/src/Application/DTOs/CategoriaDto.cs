using NexFinance.Domain.Entities;
using NexFinance.Domain.Enums;
using NexFinance.src.Infrastructure.Repositories;

namespace NexFinance.src.Application.DTOs {
    public record CategoriaDto(int Id, string Nome, string Tipo, string? Descricao);

    public record CreateCategoriaDto(string Nome, string Tipo, string? Descricao) {
        public TipoMovimento ToTipoMovimento() {
            if (!Enum.TryParse<TipoMovimento>(Tipo, true, out var tipo))
                throw new ArgumentException("Tipo inválido. Deve ser 'ENTRADA' ou 'SAIDA'.");
            return tipo;
        }
    }

    public record UpdateCategoriaDto(string Nome, string? Descricao);

}
