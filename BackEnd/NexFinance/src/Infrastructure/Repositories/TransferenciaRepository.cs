using Microsoft.EntityFrameworkCore;
using NexFinance.Domain.Entities;
using NexFinance.src.Api.Data;
using NexFinance.src.Application.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NexFinance.src.Infrastructure.Repositories {
    public class TransferenciaRepository : EfRepository<Transferencia>, ITransferenciaRepository {
        public TransferenciaRepository(NexFinanceContext db) : base(db) { }

        public async Task<IReadOnlyList<Transferencia>> ListByUsuarioAsync(int usuarioId, CancellationToken ct = default) {
            return await _set
                .AsNoTracking()
                .Where(t => t.UsuarioId == usuarioId)
                .OrderByDescending(t => t.Data)
                .ToListAsync(ct);
        }

        public override async Task<Transferencia?> GetByIdAsync(int id, CancellationToken ct = default) {
            return await _set
                .AsNoTracking()
                .Include(t => t.ContaOrigem)
                .Include(t => t.ContaDestino)
                .Include(t => t.Usuario)
                .FirstOrDefaultAsync(t => t.Id == id, ct);
        }
    }
}
