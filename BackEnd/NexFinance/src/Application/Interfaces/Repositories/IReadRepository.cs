using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NexFinance.src.Application.Interfaces.Repositories {
    public interface IReadRepository<T> where T : class {
        Task<T?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<IReadOnlyList<T>> ListAsync(CancellationToken ct = default);
        Task<(IReadOnlyList<T> Items, int Total)> GetPagedAsync(int page, int pageSize, CancellationToken ct = default);
    }
}
