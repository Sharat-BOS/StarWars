using Microsoft.EntityFrameworkCore.Migrations;

namespace StarWars.Migrations
{
    public partial class StarWarsModel_latest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Starships_Characters_CharacterID",
                table: "Starships");

            migrationBuilder.DropIndex(
                name: "IX_Starships_CharacterID",
                table: "Starships");

            migrationBuilder.DropColumn(
                name: "CharacterID",
                table: "Starships");

            migrationBuilder.AddColumn<int>(
                name: "CommanderId",
                table: "Starships",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Starships_CommanderId",
                table: "Starships",
                column: "CommanderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Starships_Characters_CommanderId",
                table: "Starships",
                column: "CommanderId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Starships_Characters_CommanderId",
                table: "Starships");

            migrationBuilder.DropIndex(
                name: "IX_Starships_CommanderId",
                table: "Starships");

            migrationBuilder.DropColumn(
                name: "CommanderId",
                table: "Starships");

            migrationBuilder.AddColumn<int>(
                name: "CharacterID",
                table: "Starships",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Starships_CharacterID",
                table: "Starships",
                column: "CharacterID");

            migrationBuilder.AddForeignKey(
                name: "FK_Starships_Characters_CharacterID",
                table: "Starships",
                column: "CharacterID",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
