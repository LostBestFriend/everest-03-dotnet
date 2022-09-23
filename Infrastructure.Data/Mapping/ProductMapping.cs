using DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Mapping
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Symbol);

            builder.HasIndex(x => x.Type);

            builder.Property(x => x.Id)
                .IsRequired()
                .HasColumnName("Id");

            builder.Property(x => x.Symbol)
                .IsRequired()
                .HasColumnName("Symbol")
                .HasColumnType("varchar(15)");

            builder.Property(x => x.UnitPrice)
                .IsRequired()
                .HasColumnName("UnitPrice");

            builder.Property(x => x.IssuanceAt)
                .IsRequired()
                .HasColumnName("IssuanceAt");

            builder.Property(x => x.ExpirationAt)
                .IsRequired()
                .HasColumnName("ExpirationAt");

            builder.Property(x => x.DaysToExpire)
                .IsRequired()
                .HasColumnName("DaysToExpire");

            builder.Property(x => x.Type)
                .IsRequired()
                .HasColumnName("Type");
        }
    }
}
