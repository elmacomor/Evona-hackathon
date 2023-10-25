using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hackathon_api.Migrations
{
    /// <inheritdoc />
    public partial class CorrectionOfTheDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketStatus",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "FreeTicket",
                table: "Tickets",
                newName: "FreeBet");

            migrationBuilder.AddColumn<int>(
                name: "BingoBetCount",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BingoFreeCount",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BingoPlayCount",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BingoWinCount",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CasinoBetCount",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CasinoFreeCount",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CasinoPlayCount",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CasinoWinCount",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CurrentUserPoints",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LiveBetCount",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LiveFreeCount",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LivePlayCount",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LiveWinCount",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PrematchBetCount",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PrematchFreeCount",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PrematchPlayCount",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PrematchWinCount",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VGBetCount",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VGFreeCount",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VGPlayCount",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VGWinCount",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ReferenceTxId",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TxId",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BingoBetCount",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BingoFreeCount",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BingoPlayCount",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BingoWinCount",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CasinoBetCount",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CasinoFreeCount",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CasinoPlayCount",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CasinoWinCount",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CurrentUserPoints",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LiveBetCount",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LiveFreeCount",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LivePlayCount",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LiveWinCount",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PrematchBetCount",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PrematchFreeCount",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PrematchPlayCount",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PrematchWinCount",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "VGBetCount",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "VGFreeCount",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "VGPlayCount",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "VGWinCount",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ReferenceTxId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "TxId",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "FreeBet",
                table: "Tickets",
                newName: "FreeTicket");

            migrationBuilder.AddColumn<int>(
                name: "TicketStatus",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
