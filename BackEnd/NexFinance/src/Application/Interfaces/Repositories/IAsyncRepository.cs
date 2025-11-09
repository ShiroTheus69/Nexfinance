using NexFinance.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NexFinance.src.Application.Interfaces.Repositories {
    public interface IAsyncRepository<T> where T : class {
        Task<T?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<IReadOnlyList<T>> ListAsync(CancellationToken ct = default);
        Task<T> AddAsync(T entity, CancellationToken ct = default);
        Task UpdateAsync(T entity, CancellationToken ct = default);
        Task DeleteAsync(T entity, CancellationToken ct = default);
        Task<(IReadOnlyList<Lancamento> Items, int Total)> GetByUsuarioPagedAsync(int usuarioId, int page, int pageSize, CancellationToken ct = default);
    }
}

