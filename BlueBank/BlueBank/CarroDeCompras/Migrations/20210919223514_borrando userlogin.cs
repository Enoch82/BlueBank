using Microsoft.EntityFrameworkCore.Migrations;

namespace CarroDeCompras.Migrations
{
    public partial class borrandouserlogin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserLoginModel");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "ClienteModel",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "ClienteModel",
                type: "varchar(200)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "ClienteModel");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "ClienteModel");

            migrationBuilder.CreateTable(
                name: "UserLoginModel",
                columns: table => new
                {
                    UserLoginId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: true),
                    ForeignClienteId = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "varchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLoginModel", x => x.UserLoginId);
                    table.ForeignKey(
                        name: "FK_UserLoginModel_ClienteModel_ForeignClienteId",
                        column: x => x.ForeignClienteId,
                        principalTable: "ClienteModel",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserLoginModel_Email",
                table: "UserLoginModel",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserLoginModel_ForeignClienteId",
                table: "UserLoginModel",
                column: "ForeignClienteId",
                unique: true);
        }
    }
}
