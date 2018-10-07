using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TransportTicketingNetwork.Database.Migrations
{
    public partial class RoutesDbset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buses_SubRoute_SubRouteId1",
                table: "Buses");

            migrationBuilder.DropForeignKey(
                name: "FK_BusSchedules_BusStop_EndBusStopId",
                table: "BusSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_BusSchedules_BusStop_StartBusStopId",
                table: "BusSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Routes_BusStop_StartBusStopId",
                table: "Routes");

            migrationBuilder.DropTable(
                name: "SubRoute");

            migrationBuilder.DropIndex(
                name: "IX_Routes_StartBusStopId",
                table: "Routes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BusStop",
                table: "BusStop");

            migrationBuilder.DropColumn(
                name: "Distance",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "StartBusStopId",
                table: "Routes");

            migrationBuilder.RenameTable(
                name: "BusStop",
                newName: "BusStops");

            migrationBuilder.RenameColumn(
                name: "SubRouteId1",
                table: "Buses",
                newName: "RouteId1");

            migrationBuilder.RenameColumn(
                name: "SubRouteId",
                table: "Buses",
                newName: "RouteId");

            migrationBuilder.RenameIndex(
                name: "IX_Buses_SubRouteId1",
                table: "Buses",
                newName: "IX_Buses_RouteId1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BusStops",
                table: "BusStops",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Buses_Routes_RouteId1",
                table: "Buses",
                column: "RouteId1",
                principalTable: "Routes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BusSchedules_BusStops_EndBusStopId",
                table: "BusSchedules",
                column: "EndBusStopId",
                principalTable: "BusStops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BusSchedules_BusStops_StartBusStopId",
                table: "BusSchedules",
                column: "StartBusStopId",
                principalTable: "BusStops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buses_Routes_RouteId1",
                table: "Buses");

            migrationBuilder.DropForeignKey(
                name: "FK_BusSchedules_BusStops_EndBusStopId",
                table: "BusSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_BusSchedules_BusStops_StartBusStopId",
                table: "BusSchedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BusStops",
                table: "BusStops");

            migrationBuilder.RenameTable(
                name: "BusStops",
                newName: "BusStop");

            migrationBuilder.RenameColumn(
                name: "RouteId1",
                table: "Buses",
                newName: "SubRouteId1");

            migrationBuilder.RenameColumn(
                name: "RouteId",
                table: "Buses",
                newName: "SubRouteId");

            migrationBuilder.RenameIndex(
                name: "IX_Buses_RouteId1",
                table: "Buses",
                newName: "IX_Buses_SubRouteId1");

            migrationBuilder.AddColumn<int>(
                name: "Distance",
                table: "Routes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "StartBusStopId",
                table: "Routes",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BusStop",
                table: "BusStop",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "SubRoute",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Distance = table.Column<int>(nullable: false),
                    EndBusStopId = table.Column<string>(nullable: true),
                    Fare = table.Column<int>(nullable: false),
                    RouteId = table.Column<string>(nullable: true),
                    RouteId1 = table.Column<int>(nullable: true)
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

            migrationBuilder.AddForeignKey(
                name: "FK_Buses_SubRoute_SubRouteId1",
                table: "Buses",
                column: "SubRouteId1",
                principalTable: "SubRoute",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BusSchedules_BusStop_EndBusStopId",
                table: "BusSchedules",
                column: "EndBusStopId",
                principalTable: "BusStop",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BusSchedules_BusStop_StartBusStopId",
                table: "BusSchedules",
                column: "StartBusStopId",
                principalTable: "BusStop",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_BusStop_StartBusStopId",
                table: "Routes",
                column: "StartBusStopId",
                principalTable: "BusStop",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
