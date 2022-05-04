using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Helniv.API.Migrations
{
    public partial class CardUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Local",
                table: "Cards",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Local",
                table: "Cards");
        }
    }
}
