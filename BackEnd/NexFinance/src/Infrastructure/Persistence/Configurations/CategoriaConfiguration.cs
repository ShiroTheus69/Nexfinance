using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexFinance.Domain.Entities;
using NexFinance.Domain.Enums;

namespace NexFinance.src.Infrastructure.Persistence.Configurations {
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria> {
        public void Configure(EntityTypeBuilder<Categoria> builder) {
            builder.ToTable("categoria");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Tipo)
                .HasConversion<string>()
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(c => c.Descricao)
                .HasColumnType("text");
        }
    }
}
