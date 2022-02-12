﻿// <auto-generated />
using BankGeeks_BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BankGeeks_BackEnd.Migrations
{
    [DbContext(typeof(GeeksContext))]
    partial class GeeksContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BankGeeks_BackEnd.Models.CalculationRecord", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FirstValue")
                        .HasColumnType("int");

                    b.Property<bool>("IsFibonacci")
                        .HasColumnType("bit");

                    b.Property<int>("Result")
                        .HasColumnType("int");

                    b.Property<int>("SecondValue")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CalculationRecords");
                });
#pragma warning restore 612, 618
        }
    }
}