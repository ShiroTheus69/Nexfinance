using NexFinance.Domain.Entities;

namespace NexFinance.src.Application.Interfaces.Repositories {
    public interface ILancamentoRepository : IAsyncRepository<Lancamento> {
        Task<IReadOnlyList<Lancamento>> GetByUsuarioAsync(int usuarioId, CancellationToken ct = default);
        Task<(IReadOnlyList<Lancamento> Items, int Total)> GetByUsuarioPagedAsync(int usuarioId, int page, int pageSize, CancellationToken ct);
        Task<(IReadOnlyList<Lancamento> Items, int Total)> QueryByUsuarioPagedAsync(int usuarioId, int page, int pageSize, CancellationToken ct = default);
    }

}
