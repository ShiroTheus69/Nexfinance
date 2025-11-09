using Microsoft.EntityFrameworkCore;
using NexFinance.Domain.Entities;
using NexFinance.Domain.Enums;

namespace NexFinance.src.Api.Data {
    public class NexFinanceContext : DbContext {
        public NexFinanceContext(DbContextOptions<NexFinanceContext> options)
            : base(options) {
        }

        // DbSets — correspondem às tabelas do banco
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Conta> Contas { get; set; }
        public DbSet<Lancamento> Lancamentos { get; set; }
        public DbSet<Transferencia> Transferencias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            // =====================
            // USUÁRIO
            // =====================
            modelBuilder.Entity<Usuario>(entity => {
                entity.ToTable("usuario");

                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nome)
                      .HasColumnName("nome")
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.Cpf)
                      .HasColumnName("cpf")
                      .IsRequired()
                      .HasMaxLength(11);

                entity.Property(e => e.Email)
                      .HasColumnName("email")
                      .IsRequired()
                      .HasMaxLength(100);

                entity.HasIndex(e => e.Email).IsUnique();

                entity.Property(e => e.SenhaHash)
                      .HasColumnName("senha_hash")
                      .IsRequired();

                entity.Property(e => e.Idade)
                      .HasColumnName("idade");

                entity.Property(e => e.DtCriacao)
                      .HasColumnName("dt_criacao")
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            // =====================
            // CATEGORIA
            // =====================
            modelBuilder.Entity<Categoria>(entity => {
                entity.ToTable("categoria");

                entity.HasKey(e => e.Id).HasName("id");
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nome)
                      .HasColumnName("nome")
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.Tipo)
                  .HasColumnName("tipo")
                  .HasConversion(
                      v => v.ToString(),
                      v => Enum.Parse<TipoMovimento>(v)
                  )
                  .HasMaxLength(10)
                  .IsRequired();

                entity.Property(e => e.Descricao)
                      .HasColumnName("descricao");
            });

            // =====================
            // CONTA
            // =====================
            modelBuilder.Entity<Conta>(entity => {
                entity.ToTable("conta");

                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nome)
                      .HasColumnName("nome")
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.Tipo)
                      .HasColumnName("tipo")
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.UsuarioId)
                      .HasColumnName("fk_usuario_id")
                      .IsRequired();

                entity.HasOne(e => e.Usuario)
                      .WithMany(u => u.Contas)
                      .HasForeignKey(e => e.UsuarioId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // =====================
            // LANÇAMENTO
            // =====================
            modelBuilder.Entity<Lancamento>(entity => {
                entity.ToTable("lancamento");

                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.UsuarioId)
                      .HasColumnName("usuario_id")
                      .IsRequired();

                entity.Property(e => e.CategoriaId)
                      .HasColumnName("categoria_id")
                      .IsRequired();

                entity.Property(e => e.ContaId)
                      .HasColumnName("conta_id")
                      .IsRequired();

                entity.Property(e => e.Tipo)
                      .HasColumnName("tipo")
                      .IsRequired()
                      .HasMaxLength(10);

                entity.Property(e => e.Valor)
                      .HasColumnName("valor")
                      .HasColumnType("decimal(12,2)")
                      .IsRequired();

                entity.Property(e => e.Data)
                      .HasColumnName("data")
                      .IsRequired();

                entity.Property(e => e.Descricao)
                      .HasColumnName("descricao");

                entity.Property(e => e.DataCriacao)
                      .HasColumnName("data_criacao")
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(l => l.Usuario)
                      .WithMany(u => u.Lancamentos)
                      .HasForeignKey(l => l.UsuarioId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(l => l.Categoria)
                      .WithMany(c => c.Lancamentos)
                      .HasForeignKey(l => l.CategoriaId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(l => l.Conta)
                      .WithMany(c => c.Lancamentos)
                      .HasForeignKey(l => l.ContaId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // =====================
            // TRANSFERÊNCIA
            // =====================
            modelBuilder.Entity<Transferencia>(entity => {
                entity.ToTable("transferencia");

                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.UsuarioId)
                      .HasColumnName("usuario_id")
                      .IsRequired();

                entity.Property(e => e.ContaOrigemId)
                      .HasColumnName("conta_origem_id")
                      .IsRequired();

                entity.Property(e => e.ContaDestinoId)
                      .HasColumnName("conta_destino_id")
                      .IsRequired();

                entity.Property(e => e.Valor)
                      .HasColumnName("valor")
                      .HasColumnType("decimal(12,2)")
                      .IsRequired();

                entity.Property(e => e.Data)
                      .HasColumnName("data")
                      .IsRequired();

                entity.Property(e => e.Descricao)
                      .HasColumnName("descricao");

                entity.Property(e => e.DataCriacao)
                      .HasColumnName("data_criacao")
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");

                // Relacionamentos
                entity.HasOne(t => t.Usuario)
                      .WithMany(u => u.Transferencias)
                      .HasForeignKey(t => t.UsuarioId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(t => t.ContaOrigem)
                      .WithMany()
                      .HasForeignKey(t => t.ContaOrigemId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(t => t.ContaDestino)
                      .WithMany()
                      .HasForeignKey(t => t.ContaDestinoId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
