// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PaySpace.Infra.Data;

namespace PaySpace.Infra.Data.Migrations
{
    [DbContext(typeof(PaySpaceDbContext))]
    [Migration("20211019144107_ChangeNullableField")]
    partial class ChangeNullableField
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PaySpace.Domain.Model.Calc", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CalcMethodId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Income")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TaxValue")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CalcMethodId");

                    b.ToTable("Calcs");
                });

            modelBuilder.Entity("PaySpace.Domain.Model.CalcMethod", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Method")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.HasKey("Id");

                    b.HasAlternateKey("PostalCode");

                    b.ToTable("CalcMethods");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ec06f78a-d3af-47f1-b5b2-bc2244dee534"),
                            Method = "Progressive",
                            PostalCode = "7441"
                        },
                        new
                        {
                            Id = new Guid("2b30e2a3-0649-4b05-8843-4b938a305bbe"),
                            Method = "FlatValue",
                            PostalCode = "A100"
                        },
                        new
                        {
                            Id = new Guid("34a41012-9070-4a72-a6e1-bf0df62d7062"),
                            Method = "FlatRate",
                            PostalCode = "7000"
                        },
                        new
                        {
                            Id = new Guid("5d4d3ce2-5897-4af9-a568-ec6faecd9249"),
                            Method = "Progressive",
                            PostalCode = "1000"
                        });
                });

            modelBuilder.Entity("PaySpace.Domain.Model.ProgressiveTable", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("From")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(18,3)");

                    b.Property<decimal>("To")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("ProgressiveTables");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1c9b871c-4f0f-46dd-89e8-5d01a5979d71"),
                            From = 0m,
                            Rate = 0.1m,
                            To = 8350m
                        },
                        new
                        {
                            Id = new Guid("a3ecdcbb-e76c-4252-8944-8280db5e23c8"),
                            From = 8351m,
                            Rate = 0.15m,
                            To = 33950m
                        },
                        new
                        {
                            Id = new Guid("9a89699a-7409-4dc2-a2a0-c1ac40f82e21"),
                            From = 33951m,
                            Rate = 0.25m,
                            To = 82250m
                        },
                        new
                        {
                            Id = new Guid("a0635549-d327-45cf-9f38-ff782452d571"),
                            From = 82251m,
                            Rate = 0.28m,
                            To = 171550m
                        },
                        new
                        {
                            Id = new Guid("dc677896-95cb-4805-8b9a-f36d4cdd28c1"),
                            From = 171551m,
                            Rate = 0.33m,
                            To = 372950m
                        },
                        new
                        {
                            Id = new Guid("ec3ad822-02fd-4dd0-878c-ed738b8ba596"),
                            From = 372951m,
                            Rate = 0.35m,
                            To = 99999999999999m
                        });
                });

            modelBuilder.Entity("PaySpace.Domain.Model.Calc", b =>
                {
                    b.HasOne("PaySpace.Domain.Model.CalcMethod", null)
                        .WithMany("Calculations")
                        .HasForeignKey("CalcMethodId");
                });

            modelBuilder.Entity("PaySpace.Domain.Model.CalcMethod", b =>
                {
                    b.Navigation("Calculations");
                });
#pragma warning restore 612, 618
        }
    }
}
