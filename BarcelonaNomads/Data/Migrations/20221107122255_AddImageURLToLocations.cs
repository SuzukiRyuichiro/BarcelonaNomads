using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarcelonaNomads.Data.Migrations
{
    public partial class AddImageURLToLocations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "Locations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "Locations");
        }
    }
}
