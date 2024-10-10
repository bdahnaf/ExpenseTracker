﻿// <auto-generated />
using System;
using ExpenseTrackerWeb.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ExpenseTrackerWeb.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241010094325_AddUniqueConstraintToCategoryNameInCategoryTable")]
    partial class AddUniqueConstraintToCategoryNameInCategoryTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ExpenseTrackerWeb.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDateTime = new DateTime(2024, 10, 10, 15, 43, 24, 186, DateTimeKind.Local).AddTicks(4128),
                            Name = "Utilities"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDateTime = new DateTime(2024, 10, 10, 15, 43, 24, 186, DateTimeKind.Local).AddTicks(4153),
                            Name = "Transport"
                        },
                        new
                        {
                            Id = 3,
                            CreatedDateTime = new DateTime(2024, 10, 10, 15, 43, 24, 186, DateTimeKind.Local).AddTicks(4154),
                            Name = "Foods"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
