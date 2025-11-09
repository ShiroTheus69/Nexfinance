namespace NexFinance.src.Application.DTOs {
    public record ContaDto(int Id, string Nome, string Tipo, int IdUsuario);

    public record CreateContaDto(string Nome, string Tipo, int IdUsuario);

    public record UpdateContaDto(string Nome, string Tipo, int IdUsuario);

}
