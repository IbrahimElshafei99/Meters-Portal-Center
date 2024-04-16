using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalUploadingMeterData.Migrations
{
    public partial class newEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UploadDate",
                table: "MeterData");

            migrationBuilder.DropColumn(
                name: "UploadUsername",
                table: "MeterData");

            migrationBuilder.AddColumn<int>(
                name: "MasterRecordId",
                table: "MeterData",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MasterRecord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UploadDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UploadUsername = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterRecord", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MeterData_MasterRecordId",
                table: "MeterData",
                column: "MasterRecordId");

            migrationBuilder.AddForeignKey(
                name: "FK_MeterData_MasterRecord_MasterRecordId",
                table: "MeterData",
                column: "MasterRecordId",
                principalTable: "MasterRecord",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MeterData_MasterRecord_MasterRecordId",
                table: "MeterData");

            migrationBuilder.DropTable(
                name: "MasterRecord");

            migrationBuilder.DropIndex(
                name: "IX_MeterData_MasterRecordId",
                table: "MeterData");

            migrationBuilder.DropColumn(
                name: "MasterRecordId",
                table: "MeterData");

            migrationBuilder.AddColumn<DateTime>(
                name: "UploadDate",
                table: "MeterData",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UploadUsername",
                table: "MeterData",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
