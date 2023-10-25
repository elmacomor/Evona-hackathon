using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hackathon_api.Migrations
{
    /// <inheritdoc />
    public partial class Ticketamountadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Games_GameId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAchivements_Games_GameId",
                table: "UserAchivements");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropIndex(
                name: "IX_UserAchivements_GameId",
                table: "UserAchivements");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_GameId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "UserAchivements");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Tickets");

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GameType",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "GameType",
                table: "Tickets");

            migrationBuilder.AddColumn<long>(
                name: "GameId",
                table: "UserAchivements",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "GameId",
                table: "Tickets",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAchivements_GameId",
                table: "UserAchivements",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_GameId",
                table: "Tickets",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Games_GameId",
                table: "Tickets",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAchivements_Games_GameId",
                table: "UserAchivements",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameId");
        }
    }
}
