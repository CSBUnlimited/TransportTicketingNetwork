using Microsoft.EntityFrameworkCore.Migrations;

namespace TransportTicketingNetwork.Database.Migrations
{
    public partial class SessionHashToIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SessionHash",
                schema: "usm",
                table: "ApplicationUserTokens",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserTokens_SessionHash",
                schema: "usm",
                table: "ApplicationUserTokens",
                column: "SessionHash");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ApplicationUserTokens_SessionHash",
                schema: "usm",
                table: "ApplicationUserTokens");

            migrationBuilder.AlterColumn<string>(
                name: "SessionHash",
                schema: "usm",
                table: "ApplicationUserTokens",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
