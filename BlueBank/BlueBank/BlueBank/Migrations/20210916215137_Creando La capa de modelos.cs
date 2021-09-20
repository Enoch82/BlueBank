using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarroDeCompras.Migrations
{
    public partial class CreandoLacapademodelos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Cuenta_Ahorros",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "Cuenta_Ahorros",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(100)", nullable: true),
                    Apellido = table.Column<string>(type: "varchar(100)", nullable: true),
                    TipoDocumento = table.Column<string>(type: "varchar(100)", nullable: true),
                    Documneto = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cuenta_Ahorros_ClienteId",
                table: "Cuenta_Ahorros",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cuenta_Ahorros_Cliente_ClienteId",
                table: "Cuenta_Ahorros",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cuenta_Ahorros_Cliente_ClienteId",
                table: "Cuenta_Ahorros");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropIndex(
                name: "IX_Cuenta_Ahorros_ClienteId",
                table: "Cuenta_Ahorros");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Cuenta_Ahorros");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "Cuenta_Ahorros");
        }
    }
}
