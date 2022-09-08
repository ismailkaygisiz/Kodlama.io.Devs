using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kodlama.io.Devs.Persistence.Migrations
{
    public partial class Mig_003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_Users_Id",
                table: "AppUsers");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AppUsers",
                newName: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_Users_UserId",
                table: "AppUsers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_Users_UserId",
                table: "AppUsers");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "AppUsers",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_Users_Id",
                table: "AppUsers",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
