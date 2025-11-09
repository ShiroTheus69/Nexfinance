using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexFinance.Domain.Entities;

namespace NexFinance.src.Infrastructure.Persistence.Configurations {
    public class LancamentoConfiguration : IEntityTypeConfiguration<Lancamento> {
        public void Configure(EntityTypeBuilder<Lancamento> builder) {
            builder.ToTable("lancamento");

            builder.HasKey(l => l.Id);

            builder.Property(l => l.Tipo)
                .HasConversion<string>()
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(l => l.Valor)
                .HasPrecision(12, 2)
                .IsRequired();

            builder.Property(l => l.Data)
                .HasColumnType("date")
                .IsRequired();

            builder.Property(l => l.Descricao)
                .HasColumnType("text");

            builder.Property(l => l.DataCriacao)
                .HasColumnType("timestamptz")
                .IsRequired();

            builder.HasOne(l => l.Usuario)
                   .WithMany(u => u.Lancamentos)
                   .HasForeignKey(l => l.UsuarioId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(l => l.Categoria)
                   .WithMany(c => c.Lancamentos)
                   .HasForeignKey(l => l.CategoriaId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(l => l.Conta)
                   .WithMany(c => c.Lancamentos)
                   .HasForeignKey(l => l.ContaId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(l => l.UsuarioId);
            builder.HasIndex(l => l.CategoriaId);
            builder.HasIndex(l => l.ContaId);
            builder.HasIndex(l => l.Data);
        }
    }
}
