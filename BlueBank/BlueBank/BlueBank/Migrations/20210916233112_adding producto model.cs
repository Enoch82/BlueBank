using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarroDeCompras.Migrations
{
    public partial class addingproductomodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Moviemiento_Producto_Cuenta_Ahorros_CuentaAhorroCuentaId",
                table: "Moviemiento_Producto");

            migrationBuilder.DropTable(
                name: "Cuenta_Ahorros");

            migrationBuilder.DropIndex(
                name: "IX_Moviemiento_Producto_CuentaAhorroCuentaId",
                table: "Moviemiento_Producto");

            migrationBuilder.DropColumn(
                name: "CuentaAhorroCuentaId",
                table: "Moviemiento_Producto");

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    ProductoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(100)", nullable: true),
                    Descripcion = table.Column<string>(type: "varchar(500)", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    ProductoId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.ProductoId);
                    table.ForeignKey(
                        name: "FK_Producto_Producto_ProductoId1",
                        column: x => x.ProductoId1,
                        principalTable: "Producto",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cuenta",
                columns: table => new
                {
                    CuentaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SaldoInicial = table.Column<decimal>(type: "numeric(13,3)", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuenta", x => x.CuentaId);
                    table.ForeignKey(
                        name: "FK_Cuenta_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cuenta_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Moviemiento_Producto_CuentaId",
                table: "Moviemiento_Producto",
                column: "CuentaId");

            migrationBuilder.CreateIndex(
                name: "IX_Cuenta_ClienteId",
                table: "Cuenta",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Cuenta_ProductoId",
                table: "Cuenta",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_ProductoId1",
                table: "Producto",
                column: "ProductoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Moviemiento_Producto_Cuenta_CuentaId",
                table: "Moviemiento_Producto",
                column: "CuentaId",
                principalTable: "Cuenta",
                principalColumn: "CuentaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Moviemiento_Producto_Cuenta_CuentaId",
                table: "Moviemiento_Producto");

            migrationBuilder.DropTable(
                name: "Cuenta");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropIndex(
                name: "IX_Moviemiento_Producto_CuentaId",
                table: "Moviemiento_Producto");

            migrationBuilder.AddColumn<int>(
                name: "CuentaAhorroCuentaId",
                table: "Moviemiento_Producto",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cuenta_Ahorros",
                columns: table => new
                {
                    CuentaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(500)", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(100)", nullable: true),
                    SaldoInicial = table.Column<decimal>(type: "numeric(13,3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuenta_Ahorros", x => x.CuentaId);
                    table.ForeignKey(
                        name: "FK_Cuenta_Ahorros_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Moviemiento_Producto_CuentaAhorroCuentaId",
                table: "Moviemiento_Producto",
                column: "CuentaAhorroCuentaId");

            migrationBuilder.CreateIndex(
                name: "IX_Cuenta_Ahorros_ClienteId",
                table: "Cuenta_Ahorros",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Moviemiento_Producto_Cuenta_Ahorros_CuentaAhorroCuentaId",
                table: "Moviemiento_Producto",
                column: "CuentaAhorroCuentaId",
                principalTable: "Cuenta_Ahorros",
                principalColumn: "CuentaId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
