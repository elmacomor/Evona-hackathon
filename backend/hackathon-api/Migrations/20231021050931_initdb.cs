using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hackathon_api.Migrations
{
    /// <inheritdoc />
    public partial class initdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Achivements",
                columns: table => new
                {
                    AchivementId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Points = table.Column<short>(type: "smallint", nullable: false),
                    Treashold = table.Column<short>(type: "smallint", nullable: false),
                    AchivementType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Achivements", x => x.AchivementId);
                });

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

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    MatchId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchesName = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.MatchId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(16)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    FirstLogin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false)
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FreeTicket = table.Column<bool>(type: "bit", nullable: false),
                    TicketDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TicketStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketID);
                    table.ForeignKey(
                        name: "FK_Tickets_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAchivements",
                columns: table => new
                {
                    UserAchivementsId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AchivementId = table.Column<long>(type: "bigint", nullable: true),
                    GameId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAchivements", x => x.UserAchivementsId);
                    table.ForeignKey(
                        name: "FK_UserAchivements_Achivements_AchivementId",
                        column: x => x.AchivementId,
                        principalTable: "Achivements",
                        principalColumn: "AchivementId");
                    table.ForeignKey(
                        name: "FK_UserAchivements_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_GameId",
                table: "Tickets",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAchivements_AchivementId",
                table: "UserAchivements",
                column: "AchivementId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAchivements_GameId",
                table: "UserAchivements",
                column: "GameId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "UserAchivements");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Achivements");

            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
