using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rhea.DAL.Migrations
{
    public partial class UpdatereservationTBL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "furnitures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "furnitures");
        }
    }
}
