using Microsoft.EntityFrameworkCore.Migrations;

namespace CarroDeCompras.Migrations
{
    public partial class CrandoindexenCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Documneto",
                table: "ClienteModel",
                newName: "Documento");

            migrationBuilder.CreateIndex(
                name: "IX_ClienteModel_TipoDocumento_Documento",
                table: "ClienteModel",
                columns: new[] { "TipoDocumento", "Documento" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ClienteModel_TipoDocumento_Documento",
                table: "ClienteModel");

            migrationBuilder.RenameColumn(
                name: "Documento",
                table: "ClienteModel",
                newName: "Documneto");
        }
    }
}
