﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using workoutTracker.Domain.DatabaseContext;

#nullable disable

namespace workoutTracker.Domain.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240304140841_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("workoutTracker.Domain.Models.Application.Exercise", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Exercise");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4a7b067b-549e-4e6a-9d57-5f6735e4f88f"),
                            Name = "Bench Press"
                        },
                        new
                        {
                            Id = new Guid("6bdc7a80-8bfa-4b8e-bbe4-0b5597279071"),
                            Name = "Squat"
                        },
                        new
                        {
                            Id = new Guid("7c9e6679-7425-40de-944b-e07fc1f90ae7"),
                            Name = "Deadlift"
                        });
                });

            modelBuilder.Entity("workoutTracker.Domain.Models.Application.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("SYSDATETIMEOFFSET()");

                    b.Property<Guid?>("DeletedById")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset?>("DeletedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("GoogleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ModifiedById")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("ModifiedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("SYSDATETIMEOFFSET()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5b3e3f65-ef2f-4646-b4d0-5f3e312bdd5e"),
                            CreatedById = new Guid("5b3e3f65-ef2f-4646-b4d0-5f3e312bdd5e"),
                            CreatedOn = new DateTimeOffset(new DateTime(2024, 3, 4, 16, 8, 41, 46, DateTimeKind.Unspecified).AddTicks(6787), new TimeSpan(0, 2, 0, 0, 0)),
                            Email = "",
                            GoogleId = "",
                            ModifiedById = new Guid("5b3e3f65-ef2f-4646-b4d0-5f3e312bdd5e"),
                            ModifiedOn = new DateTimeOffset(new DateTime(2024, 3, 4, 16, 8, 41, 46, DateTimeKind.Unspecified).AddTicks(6787), new TimeSpan(0, 2, 0, 0, 0)),
                            Name = "Automatic Process"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
