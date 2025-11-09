using Microsoft.EntityFrameworkCore;
using NexFinance.Domain.Entities;
using NexFinance.src.Api.Data;
using NexFinance.src.Application.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NexFinance.src.Infrastructure.Repositories {
    public class UsuarioRepository : EfRepository<Usuario>, IUsuarioRepository {
        public UsuarioRepository(NexFinanceContext db) : base(db) { }

        public async Task<Usuario?> GetByEmailAsync(string email, CancellationToken ct = default) {
            if (string.IsNullOrWhiteSpace(email))
                return null;

            return await _set
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower(), ct);
        }

        public override async Task<Usuario?> GetByIdAsync(int id, CancellationToken ct = default) {
            return await _set
                .AsNoTracking()
                .Include(u => u.Lancamentos)
                .Include(u => u.Transferencias)
                .FirstOrDefaultAsync(u => u.Id == id, ct);
        }
    }
}

