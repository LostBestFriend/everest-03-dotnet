using DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Mapping
{
    public class CustomerMapping : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id");

            builder.Property(x => x.FullName)
                .IsRequired()
                .HasColumnName("FullName")
                .HasColumnType("varchar(250)");

            builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType("varchar(50)");

            builder.HasIndex(x => x.Email)
                .IsUnique();

            builder.Property(x => x.Cpf)
                .IsRequired()
                .HasColumnName("Cpf")
                .HasColumnType("varchar(11)");

            builder.HasIndex(x => x.Cpf)
                .IsUnique();

            builder.Property(x => x.Cellphone)
                .IsRequired()
                .HasColumnName("Cellphone")
                .HasColumnType("varchar(13)");

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
                .HasColumnName("Country")
                .HasColumnType("varchar(30)");

            builder.Property(x => x.City)
                .IsRequired()
                .HasColumnName("City")
                .HasColumnType("varchar(50)");

            builder.Property(x => x.PostalCode)
                .IsRequired()
                .HasColumnName("PostalCode")
                .HasColumnType("varchar(11)");

            builder.Property(x => x.Address)
                .IsRequired()
                .HasColumnName("Address")
                .HasColumnType("varchar(100)");

            builder.Property(x => x.Number)
                .IsRequired()
                .HasColumnName("Number");
        }
    }
}
