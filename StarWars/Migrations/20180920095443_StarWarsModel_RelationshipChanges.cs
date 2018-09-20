using Microsoft.EntityFrameworkCore.Migrations;

namespace StarWars.Migrations
{
    public partial class StarWarsModel_RelationshipChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Episodes_EpisodeId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Starships_Characters_CommanderId",
                table: "Starships");

            migrationBuilder.DropIndex(
                name: "IX_Starships_CommanderId",
                table: "Starships");

            migrationBuilder.DropIndex(
                name: "IX_Characters_EpisodeId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "CommanderId",
                table: "Starships");

            migrationBuilder.DropColumn(
                name: "EpisodeId",
                table: "Characters");

            migrationBuilder.CreateTable(
                name: "EpisodeCharacter",
                columns: table => new
                {
                    EpisodeId = table.Column<int>(nullable: false),
                    CharacterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EpisodeCharacter", x => new { x.EpisodeId, x.CharacterId });
                    table.ForeignKey(
                        name: "FK_EpisodeCharacter_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EpisodeCharacter_Episodes_EpisodeId",
                        column: x => x.EpisodeId,
                        principalTable: "Episodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StarshipCharacter",
                columns: table => new
                {
                    StarshipId = table.Column<int>(nullable: false),
                    CharacterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StarshipCharacter", x => new { x.StarshipId, x.CharacterId });
                    table.ForeignKey(
                        name: "FK_StarshipCharacter_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StarshipCharacter_Starships_StarshipId",
                        column: x => x.StarshipId,
                        principalTable: "Starships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EpisodeCharacter_CharacterId",
                table: "EpisodeCharacter",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_StarshipCharacter_CharacterId",
                table: "StarshipCharacter",
                column: "CharacterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EpisodeCharacter");

            migrationBuilder.DropTable(
                name: "StarshipCharacter");

            migrationBuilder.AddColumn<int>(
                name: "CommanderId",
                table: "Starships",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EpisodeId",
                table: "Characters",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Starships_CommanderId",
                table: "Starships",
                column: "CommanderId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_EpisodeId",
                table: "Characters",
                column: "EpisodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Episodes_EpisodeId",
                table: "Characters",
                column: "EpisodeId",
                principalTable: "Episodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Starships_Characters_CommanderId",
                table: "Starships",
                column: "CommanderId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
