using Microsoft.EntityFrameworkCore.Migrations;

namespace CarroDeCompras.Migrations
{
    public partial class CreandoUserlogin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLogin_ClienteModel_ForeignClienteId",
                table: "UserLogin");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLogin",
                table: "UserLogin");

            migrationBuilder.RenameTable(
                name: "UserLogin",
                newName: "UserLoginModel");

            migrationBuilder.RenameIndex(
                name: "IX_UserLogin_ForeignClienteId",
                table: "UserLoginModel",
                newName: "IX_UserLoginModel_ForeignClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_UserLogin_Email",
                table: "UserLoginModel",
                newName: "IX_UserLoginModel_Email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLoginModel",
                table: "UserLoginModel",
                column: "UserLoginId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLoginModel_ClienteModel_ForeignClienteId",
                table: "UserLoginModel",
                column: "ForeignClienteId",
                principalTable: "ClienteModel",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLoginModel_ClienteModel_ForeignClienteId",
                table: "UserLoginModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLoginModel",
                table: "UserLoginModel");

            migrationBuilder.RenameTable(
                name: "UserLoginModel",
                newName: "UserLogin");

            migrationBuilder.RenameIndex(
                name: "IX_UserLoginModel_ForeignClienteId",
                table: "UserLogin",
                newName: "IX_UserLogin_ForeignClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_UserLoginModel_Email",
                table: "UserLogin",
                newName: "IX_UserLogin_Email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLogin",
                table: "UserLogin",
                column: "UserLoginId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogin_ClienteModel_ForeignClienteId",
                table: "UserLogin",
                column: "ForeignClienteId",
                principalTable: "ClienteModel",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
