using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TransportTicketingNetwork.Database.Migrations
{
    public partial class FixExpireDateTimeIssue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireDateTime",
                schema: "usm",
                table: "ApplicationUserTokens",
                nullable: false,
                defaultValueSql: "'2080-01-01'",
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "GETUTCDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EffectiveDateTime",
                schema: "usm",
                table: "ApplicationUserTokens",
                nullable: false,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "'2080-01-01'");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireDateTime",
                schema: "usm",
                table: "ApplicationUsers",
                nullable: false,
                defaultValueSql: "'2080-01-01'",
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "GETUTCDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EffectiveDateTime",
                schema: "usm",
                table: "ApplicationUsers",
                nullable: false,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "'2080-01-01'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireDateTime",
                schema: "usm",
                table: "ApplicationUserTokens",
                nullable: false,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "'2080-01-01'");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EffectiveDateTime",
                schema: "usm",
                table: "ApplicationUserTokens",
                nullable: false,
                defaultValueSql: "'2080-01-01'",
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "GETUTCDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireDateTime",
                schema: "usm",
                table: "ApplicationUsers",
                nullable: false,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "'2080-01-01'");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EffectiveDateTime",
                schema: "usm",
                table: "ApplicationUsers",
                nullable: false,
                defaultValueSql: "'2080-01-01'",
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "GETUTCDATE()");
        }
    }
}
