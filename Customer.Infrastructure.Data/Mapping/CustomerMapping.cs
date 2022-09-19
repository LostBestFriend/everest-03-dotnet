using Customer.DomainModels.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Customer.Infrastructure.Data.Mapping
{
    public class CustomerMapping : IEntityTypeConfiguration<CustomerModel>
    {
        public void Configure(EntityTypeBuilder<CustomerModel> builder)
        {
            builder.ToTable("Customers");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .HasColumnName("id");

            builder.Property(x => x.FullName)
                .IsRequired()
                .HasColumnName("FullName");

            builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnName("Email");

            builder.HasIndex(x => x.Email)
                .IsUnique();

            builder.Property(x => x.Cpf)
                .IsRequired()
                .HasColumnName("Cpf");

            builder.HasIndex(x => x.Cpf)
                .IsUnique();

            builder.Property(x => x.Cellphone)
                .IsRequired()
                .HasColumnName("Cellphone");

            builder.Property(x => x.DateOfBirth)
                .IsRequired()
                .HasColumnName("DateOfBirth");

            builder.Property(x => x.EmailSms)
                .IsRequired()
                .HasColumnName("EmailSms");

            builder.Property(x => x.Whatsapp)
                .IsRequired()
                .HasColumnName("Whatsapp");

            builder.Property(x => x.Country)
                .IsRequired()
                .HasColumnName("Country");

            builder.Property(x => x.City)
                .IsRequired()
                .HasColumnName("City");

            builder.Property(x => x.PostalCode)
                .IsRequired()
                .HasColumnName("PostalCode");

            builder.Property(x => x.Address)
                .IsRequired()
                .HasColumnName("Address");

            builder.Property(x => x.Number)
                .IsRequired()
                .HasColumnName("number");
        }
    }
}
