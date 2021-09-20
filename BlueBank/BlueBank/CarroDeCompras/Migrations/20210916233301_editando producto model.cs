using Microsoft.EntityFrameworkCore.Migrations;

namespace CarroDeCompras.Migrations
{
    public partial class editandoproductomodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producto_Producto_ProductoId1",
                table: "Producto");

            migrationBuilder.DropIndex(
                name: "IX_Producto_ProductoId1",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "ProductoId1",
                table: "Producto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductoId1",
                table: "Producto",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Producto_ProductoId1",
                table: "Producto",
                column: "ProductoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_Producto_ProductoId1",
                table: "Producto",
                column: "ProductoId1",
                principalTable: "Producto",
                principalColumn: "ProductoId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
