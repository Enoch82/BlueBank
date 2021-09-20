using Microsoft.EntityFrameworkCore.Migrations;

namespace CarroDeCompras.Migrations
{
    public partial class Creandologinyclienterelacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ClienteModel_TipoDocumento_Documento",
                table: "ClienteModel");

            migrationBuilder.CreateTable(
                name: "UserLogin",
                columns: table => new
                {
                    UserLoginId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: true),
                    Password = table.Column<string>(type: "varchar(200)", nullable: true),
                    ForeignClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin", x => x.UserLoginId);
                    table.ForeignKey(
                        name: "FK_UserLogin_ClienteModel_ForeignClienteId",
                        column: x => x.ForeignClienteId,
                        principalTable: "ClienteModel",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClienteModel_TipoDocumento_Documento",
                table: "ClienteModel",
                columns: new[] { "TipoDocumento", "Documento" },
                unique: true,
                filter: "[TipoDocumento] IS NOT NULL AND [Documento] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogin_Email",
                table: "UserLogin",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogin_ForeignClienteId",
                table: "UserLogin",
                column: "ForeignClienteId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserLogin");

            migrationBuilder.DropIndex(
                name: "IX_ClienteModel_TipoDocumento_Documento",
                table: "ClienteModel");

            migrationBuilder.CreateIndex(
                name: "IX_ClienteModel_TipoDocumento_Documento",
                table: "ClienteModel",
                columns: new[] { "TipoDocumento", "Documento" });
        }
    }
}
