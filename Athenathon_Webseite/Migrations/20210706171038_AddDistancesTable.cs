using Microsoft.EntityFrameworkCore.Migrations;

namespace Athenathon_Webseite.Migrations
{
    public partial class AddDistancesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
       /*     migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    University = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Roles = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
       */
            migrationBuilder.CreateTable(
                name: "UserDistances",
                columns: table => new
                {
                    DistanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Distance = table.Column<int>(type: "int", nullable: false),
                    TypeOfSport = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DayTime = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    AverageSpeed = table.Column<int>(type: "int", nullable: false),
                    CaloriesBurned = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDistances", x => x.DistanceId);
                    table.ForeignKey(
                        name: "FK_UserDistances_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserDistances_UserId",
                table: "UserDistances",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserDistances");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
