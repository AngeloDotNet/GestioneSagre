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
    [Migration("20220612101950_FestaIntestazione")]
    partial class FestaIntestazione
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GestioneSagre.Models.Entities.FestaEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("DataFine")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DataInizio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GuidFesta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusFesta")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Festa", (string)null);
                });

            modelBuilder.Entity("GestioneSagre.Models.Entities.IntestazioneEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Edizione")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FestaId")
                        .HasColumnType("int");

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Luogo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titolo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FestaId");

                    b.ToTable("Intestazione", (string)null);
                });

            modelBuilder.Entity("GestioneSagre.Models.Entities.VersioneEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CodiceVersione")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TestoVersione")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VersioneStato")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Versione", (string)null);
                });

            modelBuilder.Entity("GestioneSagre.Models.Entities.IntestazioneEntity", b =>
                {
                    b.HasOne("GestioneSagre.Models.Entities.FestaEntity", "Festa")
                        .WithMany("Intestazioni")
                        .HasForeignKey("FestaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Festa");
                });

            modelBuilder.Entity("GestioneSagre.Models.Entities.FestaEntity", b =>
                {
                    b.Navigation("Intestazioni");
                });
#pragma warning restore 612, 618
        }
    }
}