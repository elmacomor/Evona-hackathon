using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hackathon_api.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepositAmount",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepositCumulativeAmount",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WithdrawalCumulativeAmount",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WithdrwalAmount",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepositAmount",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DepositCumulativeAmount",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "WithdrawalCumulativeAmount",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "WithdrwalAmount",
                table: "Users");
        }
    }
}
