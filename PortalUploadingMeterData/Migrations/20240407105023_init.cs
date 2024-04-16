using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalUploadingMeterData.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inspection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StratDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inspection", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeterData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UploadDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UploadUsername = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MeterSerial = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MeterPublicKey = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    InspectionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeterData", x => x.Id);
                    table.UniqueConstraint("AK_MeterData_MeterSerial_CompanyId", x => new { x.MeterSerial, x.CompanyId });
                    table.ForeignKey(
                        name: "FK_MeterData_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MeterData_Inspection_InspectionId",
                        column: x => x.InspectionId,
                        principalTable: "Inspection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "ElSewedy" },
                    { 2, "Elster Group" },
                    { 3, "Itron" },
                    { 4, "Sappel" },
                    { 5, "Arad Group" },
                    { 6, "Zenner" },
                    { 7, "Kamstrup" },
                    { 8, "Actaris" },
                    { 9, "Siemens" },
                    { 10, "Neptune Technology Group" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MeterData_CompanyId_MeterPublicKey",
                table: "MeterData",
                columns: new[] { "CompanyId", "MeterPublicKey" },
                unique: true,
                filter: "[MeterPublicKey] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MeterData_InspectionId",
                table: "MeterData",
                column: "InspectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeterData");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Inspection");
        }
    }
}
