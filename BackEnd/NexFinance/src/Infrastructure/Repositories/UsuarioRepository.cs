using Microsoft.EntityFrameworkCore;
using NexFinance.Domain.Entities;
using NexFinance.src.Api.Data;
using NexFinance.src.Application.Interfaces.Repositories;

namespace NexFinance.src.Infrastructure.Repositories {

    public class UsuarioRepository : EfRepository<Usuario>, IUsuarioRepository {

        public UsuarioRepository(NexFinanceContext db) : base(db) { }

        public async Task<Usuario?> GetByCpfAsync(string cpf, CancellationToken ct = default) {
            if (string.IsNullOrWhiteSpace(cpf))
                return null;

            return await _set
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Cpf == cpf, ct);
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