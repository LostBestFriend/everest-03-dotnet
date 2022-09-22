using DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Mapping
{
    public class CustomerBankInfoMapping : IEntityTypeConfiguration<CustomerBankInfo>
    {
        public void Configure(EntityTypeBuilder<CustomerBankInfo> builder)
        {
            builder.ToTable("CustomerBankInfos");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id");

            builder.Property(x => x.AccountBalance)
                .IsRequired()
                .HasColumnName("AccountBalance");

            builder.Property(x => x.CustomerId)
                .IsRequired();
        }
    }
}
