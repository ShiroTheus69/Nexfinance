using NexFinance.src.Application.DTOs;

namespace NexFinance.src.Application.Interfaces {
    public interface ILancamentoService {
        Task<LancamentoDto?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<(IReadOnlyList<LancamentoDto> Items, int Total)> GetByUsuarioPagedAsync(int usuarioId, int page, int pageSize, CancellationToken ct = default);
        Task<LancamentoDto> CreateAsync(CreateLancamentoDto dto, CancellationToken ct = default);
        Task UpdateAsync(int id, UpdateLancamentoDto dto, CancellationToken ct = default);
        Task DeleteAsync(int id, CancellationToken ct = default);
    }

}
