using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexFinance.Domain.Entities;

namespace NexFinance.src.Infrastructure.Persistence.Configurations {
    public class TransferenciaConfiguration : IEntityTypeConfiguration<Transferencia> {
        public void Configure(EntityTypeBuilder<Transferencia> builder) {
            builder.ToTable("transferencia");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Valor)
                .HasPrecision(12, 2)
                .IsRequired();

            builder.Property(t => t.Data)
                .HasColumnType("date")
                .IsRequired();

            builder.Property(t => t.Descricao)
                .HasColumnType("text");

            builder.Property(t => t.DataCriacao)
                .HasColumnType("timestamptz")
                .IsRequired();

            builder.HasOne(t => t.Usuario)
                   .WithMany(u => u.Transferencias)
                   .HasForeignKey(t => t.UsuarioId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(t => t.ContaOrigem)
                   .WithMany(c => c.TransferenciasOrigem)
                   .HasForeignKey(t => t.ContaOrigemId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .IsRequired();

            builder.HasOne(t => t.ContaDestino)
                   .WithMany(c => c.TransferenciasDestino)
                   .HasForeignKey(t => t.ContaDestinoId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .IsRequired();

            builder.HasIndex(t => t.UsuarioId);
            builder.HasIndex(t => t.ContaOrigemId);
            builder.HasIndex(t => t.ContaDestinoId);
            builder.HasIndex(t => t.Data);
        }
    }
}
