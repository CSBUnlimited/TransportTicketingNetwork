using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TransportTicketingNetwork.Database.Migrations
{
    public partial class BusSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Journeys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StartBusStopId = table.Column<int>(nullable: false),
                    StartBusStopId1 = table.Column<string>(nullable: true),
                    EndBusStopId = table.Column<int>(nullable: false),
                    EndBusStopId1 = table.Column<string>(nullable: true),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Journeys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Journeys_BusStops_EndBusStopId1",
                        column: x => x.EndBusStopId1,
                        principalTable: "BusStops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Journeys_BusStops_StartBusStopId1",
                        column: x => x.StartBusStopId1,
                        principalTable: "BusStops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Journeys_EndBusStopId1",
                table: "Journeys",
                column: "EndBusStopId1");

            migrationBuilder.CreateIndex(
                name: "IX_Journeys_StartBusStopId1",
                table: "Journeys",
                column: "StartBusStopId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Journeys");
        }
    }
}
