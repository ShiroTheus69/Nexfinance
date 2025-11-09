using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexFinance.Domain.Entities;

namespace NexFinance.src.Infrastructure.Persistence.Configurations {
    public class ContaConfiguration : IEntityTypeConfiguration<Conta> {
        public void Configure(EntityTypeBuilder<Conta> builder) {
            builder.ToTable("conta");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Tipo)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
