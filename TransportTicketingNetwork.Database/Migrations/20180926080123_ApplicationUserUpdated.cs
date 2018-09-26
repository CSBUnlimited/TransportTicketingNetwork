using Microsoft.EntityFrameworkCore.Migrations;

namespace TransportTicketingNetwork.Database.Migrations
{
    public partial class ApplicationUserUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TokenHash",
                schema: "usm",
                table: "ApplicationUserTokens",
                newName: "SessionHash");

            migrationBuilder.AddColumn<bool>(
                name: "IsBlocked",
                schema: "usm",
                table: "ApplicationUsers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBlocked",
                schema: "usm",
                table: "ApplicationUsers");

            migrationBuilder.RenameColumn(
                name: "SessionHash",
                schema: "usm",
                table: "ApplicationUserTokens",
                newName: "TokenHash");
        }
    }
}
