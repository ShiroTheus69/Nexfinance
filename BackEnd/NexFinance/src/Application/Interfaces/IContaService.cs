using NexFinance.src.Application.DTOs;

namespace NexFinance.src.Application.Interfaces {
    public interface IContaService {
        Task<ContaDto> CreateAsync(CreateContaDto dto, CancellationToken ct = default);
        Task<ContaDto?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<IReadOnlyList<ContaDto>> ListAsync(CancellationToken ct = default);
    }
}
