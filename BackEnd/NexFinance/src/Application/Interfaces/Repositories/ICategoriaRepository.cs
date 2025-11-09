using NexFinance.Domain.Entities;

namespace NexFinance.src.Application.Interfaces.Repositories {
    public interface ICategoriaRepository : IAsyncRepository<Categoria> {
        Task<IReadOnlyList<Categoria>> GetByUsuarioAsync(int usuarioId, CancellationToken ct = default);
        Task<(IReadOnlyList<Categoria> Items, int Total)> QueryByUsuarioPagedAsync(int usuarioId, int page, int pageSize, CancellationToken ct = default);
    }
}
