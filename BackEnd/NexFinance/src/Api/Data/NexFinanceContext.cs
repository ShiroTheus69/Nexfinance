using Microsoft.EntityFrameworkCore;
using NexFinance.Domain.Entities;
using NexFinance.src.Domain.Entities;

namespace NexFinance.src.Api.Data {
    public class NexFinanceContext : DbContext {
        public NexFinanceContext(DbContextOptions<NexFinanceContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Conta> Contas { get; set; }
        public DbSet<Lancamento> Lancamentos { get; set; }
        public DbSet<Transferencia> Transferencias { get; set; }
        public DbSet<LogLogin> LogLogins { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            // --- USUARIO ---
            modelBuilder.Entity<Usuario>(entity => {
                entity.ToTable("usuario");

                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Nome).HasColumnName("nome");
                entity.Property(e => e.Cpf).HasColumnName("cpf");
                entity.Property(e => e.Email).HasColumnName("email");
                entity.Property(e => e.SenhaHash).HasColumnName("senha_hash");
                entity.Property(e => e.Idade).HasColumnName("idade");
                entity.Property(e => e.DtCriacao).HasColumnName("dt_criacao");

                entity.HasMany(e => e.Contas)
                    .WithOne(c => c.Usuario)
                    .HasForeignKey(c => c.UsuarioId)
                    .HasConstraintName("fk_usuario_id");
            });

            // --- CATEGORIA ---
            modelBuilder.Entity<Categoria>(entity => {
                entity.ToTable("categoria");

                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Nome).HasColumnName("nome");
                entity.Property(e => e.Descricao).HasColumnName("descricao");

                entity.Property(e => e.Tipo)
                    .HasConversion<string>()
                    .HasColumnName("tipo");
            });

            // --- CONTA ---
            modelBuilder.Entity<Conta>(entity => {
                entity.ToTable("conta");

                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Nome).HasColumnName("nome");
                entity.Property(e => e.Tipo).HasColumnName("tipo");
                entity.Property(e => e.UsuarioId).HasColumnName("fk_usuario_id");

                entity.HasOne(e => e.Usuario)
                    .WithMany(u => u.Contas)
                    .HasForeignKey(e => e.UsuarioId)
                    .HasConstraintName("fk_usuario_id");
            });

            // --- LANCAMENTO ---
            modelBuilder.Entity<Lancamento>(entity => {
                entity.ToTable("lancamento");

                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");
                entity.Property(e => e.CategoriaId).HasColumnName("categoria_id");
                entity.Property(e => e.ContaId).HasColumnName("conta_id");
                entity.Property(e => e.Tipo)
                    .HasConversion<string>()
                    .HasColumnName("tipo");
                entity.Property(e => e.Valor).HasColumnName("valor");
                entity.Property(e => e.Data).HasColumnName("data");
                entity.Property(e => e.Descricao).HasColumnName("descricao");
                entity.Property(e => e.DataCriacao).HasColumnName("data_criacao");

                entity.HasOne(e => e.Usuario)
                    .WithMany(u => u.Lancamentos)
                    .HasForeignKey(e => e.UsuarioId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Categoria)
                    .WithMany(c => c.Lancamentos)
                    .HasForeignKey(e => e.CategoriaId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Conta)
                    .WithMany(c => c.Lancamentos)
                    .HasForeignKey(e => e.ContaId)
                    .OnDelete(DeleteBehavior.Restrict);



            });

            // --- TRANSFERENCIA ---
            modelBuilder.Entity<Transferencia>(entity => {
                entity.ToTable("transferencia");

                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");
                entity.Property(e => e.ContaOrigemId).HasColumnName("conta_origem_id");
                entity.Property(e => e.ContaDestinoId).HasColumnName("conta_destino_id");
                entity.Property(e => e.Valor).HasColumnName("valor");
                entity.Property(e => e.Data).HasColumnName("data");
                entity.Property(e => e.Descricao).HasColumnName("descricao");
                entity.Property(e => e.DataCriacao).HasColumnName("data_criacao");

                entity.HasOne(e => e.Usuario)
                    .WithMany(u => u.Transferencias)
                    .HasForeignKey(e => e.UsuarioId);

                entity.HasOne(e => e.ContaOrigem)
                    .WithMany(c => c.TransferenciasOrigem)
                    .HasForeignKey(e => e.ContaOrigemId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.ContaDestino)
                    .WithMany(c => c.TransferenciasDestino)
                    .HasForeignKey(e => e.ContaDestinoId)
                    .OnDelete(DeleteBehavior.Restrict);

            
            });
        }
    }
}
