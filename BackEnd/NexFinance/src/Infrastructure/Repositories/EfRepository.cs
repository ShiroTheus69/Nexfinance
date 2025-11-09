using Microsoft.EntityFrameworkCore;
using NexFinance.Domain.Entities;
using NexFinance.src.Api.Data;
using NexFinance.src.Application.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NexFinance.src.Infrastructure.Repositories {
    public class EfRepository<T> : IAsyncRepository<T> where T : class {
        protected readonly NexFinanceContext _db;
        protected readonly DbSet<T> _set;

        public EfRepository(NexFinanceContext db) {
            _db = db;
            _set = db.Set<T>();
        }

        public virtual async Task<T> AddAsync(T entity, CancellationToken ct = default) {
            await _set.AddAsync(entity, ct);
            await _db.SaveChangesAsync(ct);
            return entity;
        }

        public virtual async Task DeleteAsync(T entity, CancellationToken ct = default) {
            _set.Remove(entity);
            await _db.SaveChangesAsync(ct);
        }

        public virtual async Task<T?> GetByIdAsync(int id, CancellationToken ct = default) {
            return await _set.FindAsync(new object[] { id }, ct);
        }

        public Task<(IReadOnlyList<Lancamento> Items, int Total)> GetByUsuarioPagedAsync(int usuarioId, int page, int pageSize, CancellationToken ct = default) {
            throw new NotImplementedException();
        }

        public virtual async Task<IReadOnlyList<T>> ListAsync(CancellationToken ct = default) {
            return await _set.AsNoTracking().ToListAsync(ct);
        }

        public virtual async Task UpdateAsync(T entity, CancellationToken ct = default) {
            _set.Update(entity);
            await _db.SaveChangesAsync(ct);
        }
    }
}

