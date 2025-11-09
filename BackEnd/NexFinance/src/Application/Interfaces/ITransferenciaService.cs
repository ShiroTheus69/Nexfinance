using NexFinance.src.Application.DTOs;

namespace NexFinance.src.Application.Interfaces {
    public interface ITransferenciaService {
        Task<TransferenciaDto?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<(IReadOnlyList<TransferenciaDto> Items, int Total)> GetByUsuarioPagedAsync(int usuarioId, int page, int pageSize, CancellationToken ct = default);
        Task<TransferenciaDto> CreateAsync(CreateTransferenciaDto dto, CancellationToken ct = default);
        Task UpdateAsync(int id, UpdateTransferenciaDto dto, CancellationToken ct = default);
        Task DeleteAsync(int id, CancellationToken ct = default);
    }
}
