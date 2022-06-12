﻿// <auto-generated />
using GestioneSagre.DataAccess.Models.Services.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GestioneSagre.DataAccess.Migrations
{
    [DbContext(typeof(GestioneSagreDbContext))]
    [Migration("20220610151022_StatoVersione")]
    partial class StatoVersione
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GestioneSagre.Models.Entities.Versione", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CodiceVersione")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TestoVersione")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VersioneStato")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Versione", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}