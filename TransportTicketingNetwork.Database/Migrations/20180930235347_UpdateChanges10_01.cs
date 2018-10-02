using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TransportTicketingNetwork.Database.Migrations
{
    public partial class UpdateChanges10_01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "UserType",
                schema: "usm",
                table: "ApplicationUsers",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateTable(
                name: "BusStop",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    BusStopName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusStop", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StartingPoint = table.Column<string>(nullable: true),
                    Destination = table.Column<string>(nullable: true),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    TotalDuration = table.Column<string>(nullable: true),
                    StartBusStopId = table.Column<string>(nullable: true),
                    EndBusStopId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusSchedules_BusStop_EndBusStopId",
                        column: x => x.EndBusStopId,
                        principalTable: "BusStop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusSchedules_BusStop_StartBusStopId",
                        column: x => x.StartBusStopId,
                        principalTable: "BusStop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Distance = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    StartBusStopId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Routes_BusStop_StartBusStopId",
                        column: x => x.StartBusStopId,
                        principalTable: "BusStop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubRoute",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RouteId1 = table.Column<int>(nullable: true),
                    RouteId = table.Column<string>(nullable: true),
                    EndBusStopId = table.Column<string>(nullable: true),
                    Distance = table.Column<int>(nullable: false),
                    Fare = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubRoute", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubRoute_BusStop_EndBusStopId",
                        column: x => x.EndBusStopId,
                        principalTable: "BusStop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubRoute_Routes_RouteId1",
                        column: x => x.RouteId1,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Buses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BusName = table.Column<string>(nullable: true),
                    BusNumber = table.Column<string>(nullable: true),
                    BusType = table.Column<string>(nullable: true),
                    NoSeats = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    SubRouteId = table.Column<string>(nullable: true),
                    SubRouteId1 = table.Column<int>(nullable: true),
                    BusScheduleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buses_BusSchedules_BusScheduleId",
                        column: x => x.BusScheduleId,
                        principalTable: "BusSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Buses_SubRoute_SubRouteId1",
                        column: x => x.SubRouteId1,
                        principalTable: "SubRoute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Buses_BusScheduleId",
                table: "Buses",
                column: "BusScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Buses_SubRouteId1",
                table: "Buses",
                column: "SubRouteId1");

            migrationBuilder.CreateIndex(
                name: "IX_BusSchedules_EndBusStopId",
                table: "BusSchedules",
                column: "EndBusStopId");

            migrationBuilder.CreateIndex(
                name: "IX_BusSchedules_StartBusStopId",
                table: "BusSchedules",
                column: "StartBusStopId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_StartBusStopId",
                table: "Routes",
                column: "StartBusStopId");

            migrationBuilder.CreateIndex(
                name: "IX_SubRoute_EndBusStopId",
                table: "SubRoute",
                column: "EndBusStopId");

            migrationBuilder.CreateIndex(
                name: "IX_SubRoute_RouteId1",
                table: "SubRoute",
                column: "RouteId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Buses");

            migrationBuilder.DropTable(
                name: "BusSchedules");

            migrationBuilder.DropTable(
                name: "SubRoute");

            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.DropTable(
                name: "BusStop");

            migrationBuilder.DropColumn(
                name: "UserType",
                schema: "usm",
                table: "ApplicationUsers");
        }
    }
}
