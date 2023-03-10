// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PaymentBackend.Settings;

#nullable disable

namespace PaymentBackend.Migrations
{
    [DbContext(typeof(PaymentDbContext))]
    [Migration("20230114195351_create database")]
    partial class createdatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PaymentBackend.Models.Currency", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<double>("Rate")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("Currencies");

                    b.HasData(
                        new
                        {
                            Id = "EUR",
                            Rate = 117.36
                        },
                        new
                        {
                            Id = "USD",
                            Rate = 109.26000000000001
                        },
                        new
                        {
                            Id = "CHF",
                            Rate = 118.56999999999999
                        },
                        new
                        {
                            Id = "GBP",
                            Rate = 132.96000000000001
                        },
                        new
                        {
                            Id = "AUD",
                            Rate = 75.510000000000005
                        },
                        new
                        {
                            Id = "BAM",
                            Rate = 60.009999999999998
                        },
                        new
                        {
                            Id = "BGN",
                            Rate = 60.009999999999998
                        },
                        new
                        {
                            Id = "CZK",
                            Rate = 4.8899999999999997
                        },
                        new
                        {
                            Id = "TRY",
                            Rate = 5.8200000000000003
                        },
                        new
                        {
                            Id = "CNY",
                            Rate = 16.140000000000001
                        },
                        new
                        {
                            Id = "CAD",
                            Rate = 81.640000000000001
                        });
                });

            modelBuilder.Entity("PaymentBackend.Models.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("RecipientEmail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("User")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("PaymentBackend.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Budget")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("boolean");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Budget = 500,
                            Email = "jelena@email.com",
                            IsVerified = false,
                            Lastname = "Dinic",
                            Name = "Jelena",
                            Password = "password",
                            PhoneNumber = 97986
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
