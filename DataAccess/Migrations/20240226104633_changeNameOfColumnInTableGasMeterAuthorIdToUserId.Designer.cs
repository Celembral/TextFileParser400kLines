﻿// <auto-generated />
using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(ParserDbContext))]
    [Migration("20240226104633_changeNameOfColumnInTableGasMeterAuthorIdToUserId")]
    partial class changeNameOfColumnInTableGasMeterAuthorIdToUserId
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DataAccess.GasMeter", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("GasMeter");
                });

            modelBuilder.Entity("DataAccess.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FIO")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double?>("GasMeterReadings")
                        .HasColumnType("double precision");

                    b.Property<string>("IdGasMeter")
                        .HasColumnType("text");

                    b.Property<string>("Period")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Sum")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("Data");
                });
#pragma warning restore 612, 618
        }
    }
}