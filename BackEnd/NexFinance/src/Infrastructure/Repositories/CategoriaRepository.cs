using NexFinance.Domain.Entities;
using NexFinance.src.Api.Data;
using NexFinance.src.Application.Interfaces.Repositories;

namespace NexFinance.src.Infrastructure.Repositories {
    public class CategoriaRepository : EfRepository<Categoria>, ICategoriaRepository {
        public CategoriaRepository(NexFinanceContext db) : base(db) { }

        public Task<IReadOnlyList<Categoria>> GetByUsuarioAsync(int usuarioId, CancellationToken ct = default) {
            throw new NotImplementedException();
        }

        public Task<(IReadOnlyList<Categoria> Items, int Total)> QueryByUsuarioPagedAsync(int usuarioId, int page, int pageSize, CancellationToken ct = default) {
            throw new NotImplementedException();
        }
    }
}

