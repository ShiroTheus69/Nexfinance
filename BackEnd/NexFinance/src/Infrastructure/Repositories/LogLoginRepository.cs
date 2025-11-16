using Microsoft.EntityFrameworkCore;
using NexFinance.Domain.Entities;
using NexFinance.src.Api.Data;
using NexFinance.src.Application.Interfaces.Repositories;
using NexFinance.src.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NexFinance.src.Infrastructure.Repositories {
    public class LogLoginRepository : ILogLoginRepository {
        private readonly NexFinanceContext _context;

        public LogLoginRepository(NexFinanceContext context) {
            _context = context;
        }

        public async Task AddAsync(LogLogin log, CancellationToken ct = default) {
            await _context.LogLogins.AddAsync(log, ct);
            await _context.SaveChangesAsync(ct);
        }
    }
}
