using Microsoft.EntityFrameworkCore;
using NexFinance.Domain.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace NexFinance.Infrastructure.Context {
    public class NexFinanceDbContext : DbContext {
        public NexFinanceDbContext(DbContextOptions<NexFinanceDbContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Categoria> Categorias => Set<Categoria>();
        public DbSet<Conta> Contas => Set<Conta>();
        public DbSet<Lancamento> Lancamentos => Set<Lancamento>();
        public DbSet<Transferencia> Transferencias => Set<Transferencia>();

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(NexFinanceDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
