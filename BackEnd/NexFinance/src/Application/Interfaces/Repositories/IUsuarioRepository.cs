using NexFinance.Domain.Entities;

namespace NexFinance.src.Application.Interfaces.Repositories {
    public interface IUsuarioRepository : IAsyncRepository<Usuario> {
        Task<Usuario?> GetByEmailAsync(string email, CancellationToken ct = default);
    }
}

