using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MetersCenter.Core_.Migrations
{
    public partial class uploadDoc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Data",
                table: "Supplies",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DocumentName",
                table: "Supplies",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                table: "Supplies");

            migrationBuilder.DropColumn(
                name: "DocumentName",
                table: "Supplies");
        }
    }
}
