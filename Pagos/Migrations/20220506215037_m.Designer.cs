﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Pagos.Data;

#nullable disable

namespace Pagos.Migrations
{
    [DbContext(typeof(AplicationDbContext))]
    [Migration("20220506215037_m")]
    partial class m
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Pagos.Models.fPagoContribAseIdep", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Zona")
                        .HasColumnType("text");

                    b.Property<string>("apellidoCasada")
                        .HasColumnType("text");

                    b.Property<string>("ciudad")
                        .HasColumnType("text");

                    b.Property<string>("complemento")
                        .HasColumnType("text");

                    b.Property<string>("departamento")
                        .HasColumnType("text");

                    b.Property<string>("direccion")
                        .HasColumnType("text");

                    b.Property<string>("email")
                        .HasColumnType("text");

                    b.Property<string>("fechaPago")
                        .HasColumnType("text");

                    b.Property<string>("formaPago")
                        .HasColumnType("text");

                    b.Property<string>("lugarPago")
                        .HasColumnType("text");

                    b.Property<int>("nroAportesPagar")
                        .HasColumnType("integer");

                    b.Property<int>("nroIdentificacion")
                        .HasColumnType("integer");

                    b.Property<int>("nroVivienda")
                        .HasColumnType("integer");

                    b.Property<int>("nuaCua")
                        .HasColumnType("integer");

                    b.Property<string>("perfilEdad")
                        .HasColumnType("text");

                    b.Property<string>("periodoCotizacion")
                        .HasColumnType("text");

                    b.Property<string>("primerApellido")
                        .HasColumnType("text");

                    b.Property<string>("primerNombre")
                        .HasColumnType("text");

                    b.Property<string>("provincia")
                        .HasColumnType("text");

                    b.Property<string>("segundoApellido")
                        .HasColumnType("text");

                    b.Property<string>("segundoNombre")
                        .HasColumnType("text");

                    b.Property<int>("telCel")
                        .HasColumnType("integer");

                    b.Property<string>("tipoAsegurado")
                        .HasColumnType("text");

                    b.Property<string>("tipoIdentificacion")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("fPagoContribAseldeps");
                });
#pragma warning restore 612, 618
        }
    }
}
