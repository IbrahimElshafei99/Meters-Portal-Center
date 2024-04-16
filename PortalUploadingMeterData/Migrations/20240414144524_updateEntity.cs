using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalUploadingMeterData.Migrations
{
    public partial class updateEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MeterData_Inspection_InspectionId",
                table: "MeterData");

            migrationBuilder.DropIndex(
                name: "IX_MeterData_InspectionId",
                table: "MeterData");

            migrationBuilder.DropColumn(
                name: "InspectionId",
                table: "MeterData");

            migrationBuilder.AddColumn<int>(
                name: "MeterId",
                table: "Inspection",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Inspection_MeterId",
                table: "Inspection",
                column: "MeterId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Inspection_MeterData_MeterId",
                table: "Inspection",
                column: "MeterId",
                principalTable: "MeterData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inspection_MeterData_MeterId",
                table: "Inspection");

            migrationBuilder.DropIndex(
                name: "IX_Inspection_MeterId",
                table: "Inspection");

            migrationBuilder.DropColumn(
                name: "MeterId",
                table: "Inspection");

            migrationBuilder.AddColumn<int>(
                name: "InspectionId",
                table: "MeterData",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MeterData_InspectionId",
                table: "MeterData",
                column: "InspectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_MeterData_Inspection_InspectionId",
                table: "MeterData",
                column: "InspectionId",
                principalTable: "Inspection",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
