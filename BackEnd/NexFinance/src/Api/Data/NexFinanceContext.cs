using Microsoft.EntityFrameworkCore;
using NexFinance.Domain.Entities;

namespace NexFinance.Api.Data {
    public class NexFinanceContext : DbContext {
        public NexFinanceContext(DbContextOptions<NexFinanceContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Conta> Contas { get; set; }
        public DbSet<Lancamento> Lancamentos { get; set; }
        public DbSet<Transferencia> Transferencias { get; set; }
    }
}
