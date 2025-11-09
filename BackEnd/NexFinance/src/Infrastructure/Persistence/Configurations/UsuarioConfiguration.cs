using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexFinance.Domain.Entities;

namespace NexFinance.src.Infrastructure.Persistence.Configurations {
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario> {
        public void Configure(EntityTypeBuilder<Usuario> builder) {
            builder.ToTable("usuarios");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Cpf)
                .IsRequired()
                .HasMaxLength(11);

            builder.HasIndex(u => u.Cpf).IsUnique();

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(u => u.Email).IsUnique();
            builder.Property(u => u.SenhaHash)
                .IsRequired()
                .HasColumnType("bytea");

            builder.Property(u => u.Idade);

            builder.Property(u => u.DtCriacao)
                .HasColumnType("timestamptz")
                .IsRequired();
        }
    }
}
