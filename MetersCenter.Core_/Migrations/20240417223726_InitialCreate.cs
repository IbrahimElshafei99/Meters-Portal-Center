using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MetersCenter.Core_.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MeterProviders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeterProviders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Supplies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UploadDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UploadUsername = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InspectionStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InspectionEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InspectorUsername = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MeterProviderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Supplies_MeterProviders_MeterProviderId",
                        column: x => x.MeterProviderId,
                        principalTable: "MeterProviders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MeterData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeterSerial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeterPublicKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SuppliesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeterData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeterData_Supplies_SuppliesId",
                        column: x => x.SuppliesId,
                        principalTable: "Supplies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MeterProviders",
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
                name: "IX_MeterData_SuppliesId",
                table: "MeterData",
                column: "SuppliesId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplies_MeterProviderId",
                table: "Supplies",
                column: "MeterProviderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeterData");

            migrationBuilder.DropTable(
                name: "Supplies");

            migrationBuilder.DropTable(
                name: "MeterProviders");
        }
    }
}
