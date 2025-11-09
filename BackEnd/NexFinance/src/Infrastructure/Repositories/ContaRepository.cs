using Microsoft.EntityFrameworkCore;
using NexFinance.Domain.Entities;
using NexFinance.src.Api.Data;
using NexFinance.src.Application.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NexFinance.src.Infrastructure.Repositories {
    public class ContaRepository : EfRepository<Conta>, IContaRepository {
        public ContaRepository(NexFinanceContext db) : base(db) { }

        public override async Task<Conta?> GetByIdAsync(int id, CancellationToken ct = default) {
            return await _set
                .AsNoTracking()
                .Include(c => c.Lancamentos)
                .Include(c => c.TransferenciasOrigem)
                .Include(c => c.TransferenciasDestino)
                .FirstOrDefaultAsync(c => c.Id == id, ct);
        }
    }
}

