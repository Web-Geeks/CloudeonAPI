using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cloudeon.API.Migrations
{
    public partial class RollbackChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeoLocations_Vehicles_VehicleId",
                table: "GeoLocations");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleId",
                table: "GeoLocations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GeoLocations_Vehicles_VehicleId",
                table: "GeoLocations",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeoLocations_Vehicles_VehicleId",
                table: "GeoLocations");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleId",
                table: "GeoLocations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_GeoLocations_Vehicles_VehicleId",
                table: "GeoLocations",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id");
        }
    }
}
