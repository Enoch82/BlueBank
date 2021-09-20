using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarroDeCompras.Migrations
{
    public partial class adicionandoMovimientoProductoModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Moviemiento_Producto",
                columns: table => new
                {
                    MovimientoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha_Operacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Concepto = table.Column<string>(type: "varchar(500)", nullable: true),
                    Cargos = table.Column<decimal>(type: "numeric(13,3)", nullable: false),
                    Abonos = table.Column<decimal>(type: "numeric(13,3)", nullable: false),
                    CuentaAhorroCuentaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moviemiento_Producto", x => x.MovimientoId);
                    table.ForeignKey(
                        name: "FK_Moviemiento_Producto_Cuenta_Ahorros_CuentaAhorroCuentaId",
                        column: x => x.CuentaAhorroCuentaId,
                        principalTable: "Cuenta_Ahorros",
                        principalColumn: "CuentaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Moviemiento_Producto_CuentaAhorroCuentaId",
                table: "Moviemiento_Producto",
                column: "CuentaAhorroCuentaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Moviemiento_Producto");
        }
    }
}
