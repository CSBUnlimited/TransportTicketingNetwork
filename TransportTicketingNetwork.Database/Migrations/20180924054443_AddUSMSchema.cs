using Microsoft.EntityFrameworkCore.Migrations;

namespace TransportTicketingNetwork.Database.Migrations
{
    public partial class AddUSMSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_ApplicationUsers_ApplicationUserId",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.EnsureSchema(
                name: "usm");

            migrationBuilder.RenameTable(
                name: "ApplicationUserTokens",
                newName: "ApplicationUserTokens",
                newSchema: "usm");

            migrationBuilder.RenameTable(
                name: "ApplicationUsers",
                newName: "ApplicationUsers",
                newSchema: "usm");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users",
                newSchema: "usm");

            migrationBuilder.RenameIndex(
                name: "IX_User_ApplicationUserId",
                schema: "usm",
                table: "Users",
                newName: "IX_Users_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                schema: "usm",
                table: "Users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_ApplicationUsers_ApplicationUserId",
                schema: "usm",
                table: "Users",
                column: "ApplicationUserId",
                principalSchema: "usm",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_ApplicationUsers_ApplicationUserId",
                schema: "usm",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                schema: "usm",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "ApplicationUserTokens",
                schema: "usm",
                newName: "ApplicationUserTokens");

            migrationBuilder.RenameTable(
                name: "ApplicationUsers",
                schema: "usm",
                newName: "ApplicationUsers");

            migrationBuilder.RenameTable(
                name: "Users",
                schema: "usm",
                newName: "User");

            migrationBuilder.RenameIndex(
                name: "IX_Users_ApplicationUserId",
                table: "User",
                newName: "IX_User_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_ApplicationUsers_ApplicationUserId",
                table: "User",
                column: "ApplicationUserId",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
