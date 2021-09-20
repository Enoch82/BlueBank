using Microsoft.EntityFrameworkCore.Migrations;

namespace CarroDeCompras.Migrations
{
    public partial class CreandoModelodeCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cuenta_Cliente_ClienteId",
                table: "Cuenta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente");

            migrationBuilder.RenameTable(
                name: "Cliente",
                newName: "ClienteModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClienteModel",
                table: "ClienteModel",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cuenta_ClienteModel_ClienteId",
                table: "Cuenta",
                column: "ClienteId",
                principalTable: "ClienteModel",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cuenta_ClienteModel_ClienteId",
                table: "Cuenta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClienteModel",
                table: "ClienteModel");

            migrationBuilder.RenameTable(
                name: "ClienteModel",
                newName: "Cliente");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cuenta_Cliente_ClienteId",
                table: "Cuenta",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
