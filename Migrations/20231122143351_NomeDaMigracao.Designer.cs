﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TccDB;

#nullable disable

namespace RepositorioTCC.Migrations
{
    [DbContext(typeof(TCCDbContext))]
    [Migration("20231122143351_NomeDaMigracao")]
    partial class NomeDaMigracao
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("Tcc", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Ano")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Autor")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Orientador")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PalavrasChave")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Resumo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Tccs");
                });
#pragma warning restore 612, 618
        }
    }
}
