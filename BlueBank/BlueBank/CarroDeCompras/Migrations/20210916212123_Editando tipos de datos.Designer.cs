﻿// <auto-generated />
using CarroDeCompras.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarroDeCompras.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20210916212123_Editando tipos de datos")]
    partial class Editandotiposdedatos
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CarroDeCompras.Models.CuentaAhorro", b =>
                {
                    b.Property<int>("CuentaId")
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

                    b.Property<decimal>("SaldoInicial")
                        .HasColumnType("numeric(13,3)")
                        .HasColumnName("SaldoInicial");

                    b.HasKey("CuentaId");

                    b.ToTable("Cuenta_Ahorros");
                });
#pragma warning restore 612, 618
        }
    }
}