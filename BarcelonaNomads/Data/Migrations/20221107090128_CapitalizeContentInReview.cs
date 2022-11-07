using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarcelonaNomads.Data.Migrations
{
    public partial class CapitalizeContentInReview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "content",
                table: "Reviews",
                newName: "Content");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Reviews",
                newName: "content");
        }
    }
}
