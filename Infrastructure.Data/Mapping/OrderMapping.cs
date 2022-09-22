using DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Mapping
{
    public class OrderMapping : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.LiquidatedAt);

            builder.Property(x => x.Id)
                .IsRequired()
                .HasColumnName("Id");

            builder.Property(x => x.Quotes)
                .IsRequired()
                .HasColumnName("Quotes");

            builder.Property(x => x.UnitPrice)
                .IsRequired()
                .HasColumnName("UnitPrice");

            builder.Property(x => x.NetValue)
                .IsRequired()
                .HasColumnName("NetValue");

            builder.Property(x => x.LiquidatedAt)
                .IsRequired()
                .HasColumnName("LiquidatedAt");

            builder.Property(x => x.Direction)
                .IsRequired()
                .HasColumnName("Direction");

            builder.HasOne(x => x.Portfolio)
                .WithMany(p => p.Orders)
                .HasForeignKey(pt => pt.PortfolioId);
        }
    }
}
