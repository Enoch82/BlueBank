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
    [Migration("20210920053444_Creando saldo en Movimiento")]
    partial class CreandosaldoenMovimiento
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

                    b.Property<string>("Documento")
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Documento");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Email");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit")
                        .HasColumnName("Estado");

                    b.Property<string>("Nombre")
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Nombre");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasColumnName("Password");

                    b.Property<string>("TipoDocumento")
                        .HasColumnType("varchar(100)")
                        .HasColumnName("TipoDocumento");

                    b.HasKey("ClienteId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("TipoDocumento", "Documento")
                        .IsUnique()
                        .HasFilter("[TipoDocumento] IS NOT NULL AND [Documento] IS NOT NULL");

                    b.ToTable("ClienteModel");
                });

            modelBuilder.Entity("CarroDeCompras.Models.Cuenta", b =>
                {
                    b.Property<int>("CuentaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2")
                        .HasColumnName("FechaCreacion");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.Property<decimal>("SaldoInicial")
                        .HasColumnType("numeric(13,3)")
                        .HasColumnName("SaldoInicial");

                    b.HasKey("CuentaId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("ProductoId");

                    b.ToTable("Cuenta");
                });

            modelBuilder.Entity("CarroDeCompras.Models.MoviemientoProducto", b =>
                {
                    b.Property<int>("MovimientoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Abonos")
                        .HasColumnType("numeric(13,3)")
                        .HasColumnName("Abonos");

                    b.Property<decimal>("Cargos")
                        .HasColumnType("numeric(13,3)")
                        .HasColumnName("Cargos");

                    b.Property<string>("Concepto")
                        .HasColumnType("varchar(500)")
                        .HasColumnName("Concepto");

                    b.Property<int>("CuentaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaOperacion")
                        .HasColumnType("datetime2")
                        .HasColumnName("Fecha_Operacion");

                    b.Property<decimal>("Saldo")
                        .HasColumnType("numeric(13,3)")
                        .HasColumnName("Saldo");

                    b.HasKey("MovimientoId");

                    b.HasIndex("CuentaId");

                    b.ToTable("Moviemiento_Producto");
                });

            modelBuilder.Entity("CarroDeCompras.Models.Producto", b =>
                {
                    b.Property<int>("ProductoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("varchar(500)")
                        .HasColumnName("Descripcion");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Nombre");

                    b.HasKey("ProductoId");

                    b.ToTable("Producto");
                });

            modelBuilder.Entity("CarroDeCompras.Models.Cuenta", b =>
                {
                    b.HasOne("CarroDeCompras.Models.Cliente", "Cliente")
                        .WithMany("CuentaAhorros")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarroDeCompras.Models.Producto", "Producto")
                        .WithMany("Cuenta")
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("CarroDeCompras.Models.MoviemientoProducto", b =>
                {
                    b.HasOne("CarroDeCompras.Models.Cuenta", "Cuenta")
                        .WithMany("MoviemientoProducto")
                        .HasForeignKey("CuentaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cuenta");
                });

            modelBuilder.Entity("CarroDeCompras.Models.Cliente", b =>
                {
                    b.Navigation("CuentaAhorros");
                });

            modelBuilder.Entity("CarroDeCompras.Models.Cuenta", b =>
                {
                    b.Navigation("MoviemientoProducto");
                });

            modelBuilder.Entity("CarroDeCompras.Models.Producto", b =>
                {
                    b.Navigation("Cuenta");
                });
#pragma warning restore 612, 618
        }
    }
}
