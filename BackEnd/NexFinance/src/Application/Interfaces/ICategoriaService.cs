using NexFinance.src.Application.DTOs;

namespace NexFinance.src.Application.Interfaces {
    public interface ICategoriaService {
        Task<CategoriaDto> CreateAsync(CreateCategoriaDto dto, CancellationToken ct = default);
        Task<CategoriaDto?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<IReadOnlyList<CategoriaDto>> ListAsync(CancellationToken ct = default);
    }
}
