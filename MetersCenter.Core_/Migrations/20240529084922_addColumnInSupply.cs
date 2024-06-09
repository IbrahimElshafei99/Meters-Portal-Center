using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MetersCenter.Core_.Migrations
{
    public partial class addColumnInSupply : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Supplies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Supplies");
        }
    }
}
