using Microsoft.EntityFrameworkCore.Migrations;

namespace Athenathon_Webseite.Migrations
{
    public partial class setForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDistances_Users_UserId",
                table: "UserDistances");

            migrationBuilder.DropIndex(
                name: "IX_UserDistances_UserId",
                table: "UserDistances");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserDistances");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserDistances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserDistances_Id",
                table: "UserDistances",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserDistances_Users_Id",
                table: "UserDistances",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDistances_Users_Id",
                table: "UserDistances");

            migrationBuilder.DropIndex(
                name: "IX_UserDistances_Id",
                table: "UserDistances");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserDistances");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UserDistances",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserDistances_UserId",
                table: "UserDistances",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserDistances_Users_UserId",
                table: "UserDistances",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
