using Microsoft.EntityFrameworkCore;
using NexFinance.Domain.Entities;
using NexFinance.src.Api.Data;
using NexFinance.src.Application.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NexFinance.src.Infrastructure.Repositories {
    public class LancamentoRepository : EfRepository<Lancamento>, ILancamentoRepository {
        public LancamentoRepository(NexFinanceContext db) : base(db) { }

        public async Task<(IReadOnlyList<Lancamento> Items, int Total)> GetByUsuarioPagedAsync(int usuarioId, int page, int pageSize, CancellationToken ct = default) {

            page = page < 1 ? 1 : page;
            pageSize = pageSize < 1 ? 20 : pageSize;

            var query = _set
                .AsNoTracking()
                .Where(l => l.UsuarioId == usuarioId)
                .OrderByDescending(l => l.Data);

            var total = await query.CountAsync(ct);
            var items = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(ct);

            return (items, total);
        }

        public override async Task<Lancamento?> GetByIdAsync(int id, CancellationToken ct = default) {
            return await _set
                .AsNoTracking()
                .Include(l => l.Categoria)
                .Include(l => l.Conta)
                .Include(l => l.Usuario)
                .FirstOrDefaultAsync(l => l.Id == id, ct);
        }

        Task<IReadOnlyList<Lancamento>> ILancamentoRepository.GetByUsuarioAsync(int usuarioId, CancellationToken ct) {
            throw new NotImplementedException();
        }

        Task<(IReadOnlyList<Lancamento> Items, int Total)> ILancamentoRepository.QueryByUsuarioPagedAsync(int usuarioId, int page, int pageSize, CancellationToken ct) {
            throw new NotImplementedException();
        }

    }
}

