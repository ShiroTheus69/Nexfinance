using NexFinance.Domain.Entities;

namespace NexFinance.src.Application.Interfaces.Repositories {
    public interface ITransferenciaRepository : IAsyncRepository<Transferencia> {
        Task<IReadOnlyList<Transferencia>> ListByUsuarioAsync(int usuarioId, CancellationToken ct = default);
    }
}
