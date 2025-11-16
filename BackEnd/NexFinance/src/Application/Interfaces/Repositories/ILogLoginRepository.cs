using NexFinance.Domain.Entities;
using NexFinance.src.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace NexFinance.src.Application.Interfaces.Repositories {
    public interface ILogLoginRepository {
        Task AddAsync(LogLogin log, CancellationToken ct = default);
    }
}
