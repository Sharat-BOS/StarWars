using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StarWars.Migrations
{
    public partial class StarWarsModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CharacterGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GroupName = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CharacterTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CharacterTypeName = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Factions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FactionName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CharacterName = table.Column<string>(maxLength: 200, nullable: true),
                    CharacterTypeID = table.Column<int>(nullable: false),
                    CharacterGroupID = table.Column<int>(nullable: false),
                    HomePlanet = table.Column<string>(maxLength: 200, nullable: true),
                    Purpose = table.Column<string>(maxLength: 200, nullable: true),
                    FactionID = table.Column<int>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    EpisodeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_CharacterGroups_CharacterGroupID",
                        column: x => x.CharacterGroupID,
                        principalTable: "CharacterGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Characters_CharacterTypes_CharacterTypeID",
                        column: x => x.CharacterTypeID,
                        principalTable: "CharacterTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Characters_Factions_FactionID",
                        column: x => x.FactionID,
                        principalTable: "Factions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Starships",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StarshipName = table.Column<string>(maxLength: 50, nullable: true),
                    CharacterID = table.Column<int>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Starships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Starships_Characters_CharacterID",
                        column: x => x.CharacterID,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Episodes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EpisodeName = table.Column<string>(nullable: true),
                    StarshipId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Episodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Episodes_Starships_StarshipId",
                        column: x => x.StarshipId,
                        principalTable: "Starships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_CharacterGroupID",
                table: "Characters",
                column: "CharacterGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_CharacterTypeID",
                table: "Characters",
                column: "CharacterTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_EpisodeId",
                table: "Characters",
                column: "EpisodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_FactionID",
                table: "Characters",
                column: "FactionID");

            migrationBuilder.CreateIndex(
                name: "IX_Episodes_StarshipId",
                table: "Episodes",
                column: "StarshipId");

            migrationBuilder.CreateIndex(
                name: "IX_Starships_CharacterID",
                table: "Starships",
                column: "CharacterID");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Episodes_EpisodeId",
                table: "Characters",
                column: "EpisodeId",
                principalTable: "Episodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_CharacterGroups_CharacterGroupID",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_CharacterTypes_CharacterTypeID",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Episodes_EpisodeId",
                table: "Characters");

            migrationBuilder.DropTable(
                name: "CharacterGroups");

            migrationBuilder.DropTable(
                name: "CharacterTypes");

            migrationBuilder.DropTable(
                name: "Episodes");

            migrationBuilder.DropTable(
                name: "Starships");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Factions");
        }
    }
}
