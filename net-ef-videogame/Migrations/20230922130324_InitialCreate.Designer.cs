﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using net_ef_videogame;
using System;

#nullable disable

namespace net_ef_videogame.Migrations
{
    [DbContext(typeof(VideogameContext))]
    [Migration("20230922130324_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("net_ef_videogame.SoftwareHouses", b =>
                {
                    b.Property<long>("SoftwareHousesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("SoftwareHousesId"));

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SoftwareHousesId");

                    b.ToTable("SoftwareHouses");
                });

            modelBuilder.Entity("net_ef_videogame.Videogames", b =>
                {
                    b.Property<long>("VideogamesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("VideogamesId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Overview")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("SoftwareHouseId")
                        .HasColumnType("bigint");

                    b.Property<long>("SoftwareHousesId")
                        .HasColumnType("bigint");

                    b.HasKey("VideogamesId");

                    b.HasIndex("SoftwareHousesId");

                    b.ToTable("Videogames");
                });

            modelBuilder.Entity("net_ef_videogame.Videogames", b =>
                {
                    b.HasOne("net_ef_videogame.SoftwareHouses", "SoftwareHouses")
                        .WithMany("Videogames")
                        .HasForeignKey("SoftwareHousesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SoftwareHouses");
                });

            modelBuilder.Entity("net_ef_videogame.SoftwareHouses", b =>
                {
                    b.Navigation("Videogames");
                });
#pragma warning restore 612, 618
        }
    }
}