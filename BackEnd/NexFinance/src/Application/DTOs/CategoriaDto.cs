namespace NexFinance.src.Application.DTOs {
    public record CategoriaDto(int Id, string Nome, string Tipo, string? Descricao);

    public record CreateCategoriaDto(string Nome, string Tipo, string? Descricao);

    public record UpdateCategoriaDto(string Nome, string? Descricao);

}
