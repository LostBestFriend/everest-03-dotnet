// <auto-generated />
using System;
using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(FeatureContext))]
    [Migration("20220920193843_NewMigration")]
    partial class NewMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DomainModels.Customer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Address");

                    b.Property<string>("Cellphone")
                        .IsRequired()
                        .HasColumnType("varchar(13)")
                        .HasColumnName("Cellphone");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("City");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("varchar(30)")
                        .HasColumnName("Country");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("varchar(11)")
                        .HasColumnName("Cpf");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("DateOfBirth");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Email");

                    b.Property<bool>("EmailSms")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("EmailSms");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("varchar(250)")
                        .HasColumnName("FullName");

                    b.Property<int>("Number")
                        .HasColumnType("int")
                        .HasColumnName("number");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("varchar(11)")
                        .HasColumnName("PostalCode");

                    b.Property<bool>("Whatsapp")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("Whatsapp");

                    b.HasKey("Id");

                    b.HasIndex("Cpf")
                        .IsUnique();

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Customers", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
