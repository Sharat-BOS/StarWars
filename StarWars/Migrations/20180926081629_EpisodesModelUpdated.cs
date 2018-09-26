using Microsoft.EntityFrameworkCore.Migrations;

namespace StarWars.Migrations
{
    public partial class EpisodesModelUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Episodes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Summary",
                table: "Episodes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Episodes");

            migrationBuilder.DropColumn(
                name: "Summary",
                table: "Episodes");
        }
    }
}
