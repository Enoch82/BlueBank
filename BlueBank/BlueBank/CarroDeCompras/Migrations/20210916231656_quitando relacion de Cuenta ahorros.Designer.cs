﻿// <auto-generated />
using System;
using CarroDeCompras.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarroDeCompras.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20210916231656_quitando relacion de Cuenta ahorros")]
    partial class quitandorelaciondeCuentaahorros
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CarroDeCompras.Models.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Apellido");

                    b.Property<string>("Documneto")
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Documneto");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit")
                        .HasColumnName("Estado");

                    b.Property<string>("Nombre")
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Nombre");

                    b.Property<string>("TipoDocumento")
                        .HasColumnType("varchar(100)")
                        .HasColumnName("TipoDocumento");

                    b.HasKey("ClienteId");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("CarroDeCompras.Models.CuentaAhorro", b =>
                {
                    b.Property<int>("CuentaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("varchar(500)")
                        .HasColumnName("Descripcion");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2")
                        .HasColumnName("FechaCreacion");

                    b.Property<string>("Nombre")
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Nombre");

                    b.Property<decimal>("SaldoInicial")
                        .HasColumnType("numeric(13,3)")
                        .HasColumnName("SaldoInicial");

                    b.HasKey("CuentaId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Cuenta_Ahorros");
                });

            modelBuilder.Entity("CarroDeCompras.Models.CuentaAhorro", b =>
                {
                    b.HasOne("CarroDeCompras.Models.Cliente", "Cliente")
                        .WithMany("CuentaAhorros")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("CarroDeCompras.Models.Cliente", b =>
                {
                    b.Navigation("CuentaAhorros");
                });
#pragma warning restore 612, 618
        }
    }
}