﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using server.Models;

#nullable disable

namespace server.Migrations
{
    [DbContext(typeof(NBFPDbContext))]
    [Migration("20250328233448_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("server.Models.Household", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Adults")
                        .HasColumnType("integer");

                    b.Property<int>("Children")
                        .HasColumnType("integer");

                    b.Property<DateTime>("EligibilityAttestationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("EligibilityType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Infants")
                        .HasColumnType("integer");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Members")
                        .HasColumnType("integer");

                    b.Property<string>("Others_Authorized")
                        .HasColumnType("text");

                    b.Property<int>("Seniors")
                        .HasColumnType("integer");

                    b.Property<int>("Toddlers")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Households");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "123 Main St, Buffalo, NY, 14203",
                            Adults = 1,
                            Children = 2,
                            EligibilityAttestationDate = new DateTime(2025, 3, 18, 23, 34, 47, 935, DateTimeKind.Utc).AddTicks(8601),
                            EligibilityType = "Categorical",
                            Infants = 1,
                            LastUpdated = new DateTime(2025, 3, 18, 23, 34, 47, 935, DateTimeKind.Utc).AddTicks(8691),
                            Members = 5,
                            Seniors = 0,
                            Toddlers = 1
                        },
                        new
                        {
                            Id = 2,
                            Address = "456 Elm St, Buffalo, NY, 14203",
                            Adults = 2,
                            Children = 1,
                            EligibilityAttestationDate = new DateTime(2025, 3, 23, 23, 34, 47, 935, DateTimeKind.Utc).AddTicks(8756),
                            EligibilityType = "Income",
                            Infants = 0,
                            LastUpdated = new DateTime(2025, 3, 23, 23, 34, 47, 935, DateTimeKind.Utc).AddTicks(8757),
                            Members = 3,
                            Seniors = 0,
                            Toddlers = 0
                        });
                });

            modelBuilder.Entity("server.Models.HouseholdMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("HouseholdId")
                        .HasColumnType("integer");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("HouseholdMembers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 0,
                            FirstName = "John",
                            HouseholdId = 1,
                            LastName = "Doe"
                        },
                        new
                        {
                            Id = 2,
                            Age = 0,
                            FirstName = "Jane",
                            HouseholdId = 1,
                            LastName = "Doe"
                        },
                        new
                        {
                            Id = 3,
                            Age = 0,
                            FirstName = "Alice",
                            HouseholdId = 1,
                            LastName = "Doe"
                        },
                        new
                        {
                            Id = 4,
                            Age = 0,
                            FirstName = "Bob",
                            HouseholdId = 1,
                            LastName = "Doe"
                        },
                        new
                        {
                            Id = 5,
                            Age = 0,
                            FirstName = "Al",
                            HouseholdId = 1,
                            LastName = "Doe"
                        },
                        new
                        {
                            Id = 6,
                            Age = 0,
                            FirstName = "Alice",
                            HouseholdId = 2,
                            LastName = "Smith"
                        },
                        new
                        {
                            Id = 7,
                            Age = 0,
                            FirstName = "Bob",
                            HouseholdId = 2,
                            LastName = "Smith"
                        },
                        new
                        {
                            Id = 8,
                            Age = 0,
                            FirstName = "Charlie",
                            HouseholdId = 2,
                            LastName = "Smith"
                        });
                });

            modelBuilder.Entity("server.Models.HouseholdVisit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("HouseholdId")
                        .HasColumnType("integer");

                    b.Property<string>("StaffName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("VisitDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("HouseholdVisits");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            HouseholdId = 1,
                            StaffName = "Cameron Turner",
                            VisitDate = new DateTime(2025, 3, 23, 23, 34, 47, 935, DateTimeKind.Utc).AddTicks(9649)
                        },
                        new
                        {
                            Id = 2,
                            HouseholdId = 2,
                            StaffName = "Cameron Turner",
                            VisitDate = new DateTime(2025, 3, 26, 23, 34, 47, 935, DateTimeKind.Utc).AddTicks(9713)
                        });
                });

            modelBuilder.Entity("server.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Password = "nbfpfeedsmore",
                            Username = "nbfpAdmin"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
