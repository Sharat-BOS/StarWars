using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StarWars.Migrations
{
    public partial class initial1 : Migration
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
                name: "Pies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ShortDescription = table.Column<string>(nullable: true),
                    LongDescription = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    IsInStock = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Starships",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StarshipName = table.Column<string>(maxLength: 50, nullable: true),
                    ImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Starships", x => x.Id);
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
                    FactionID = table.Column<int>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true)
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
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateIndex(
                name: "IX_Characters_CharacterGroupID",
                table: "Characters",
                column: "CharacterGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_CharacterTypeID",
                table: "Characters",
                column: "CharacterTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_FactionID",
                table: "Characters",
                column: "FactionID");

            migrationBuilder.CreateIndex(
                name: "IX_EpisodeCharacter_CharacterId",
                table: "EpisodeCharacter",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Episodes_EpisodeName",
                table: "Episodes",
                column: "EpisodeName",
                unique: true,
                filter: "[EpisodeName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Episodes_StarshipId",
                table: "Episodes",
                column: "StarshipId");

            migrationBuilder.CreateIndex(
                name: "IX_Factions_FactionName",
                table: "Factions",
                column: "FactionName",
                unique: true,
                filter: "[FactionName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_StarshipCharacter_CharacterId",
                table: "StarshipCharacter",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Starships_StarshipName",
                table: "Starships",
                column: "StarshipName",
                unique: true,
                filter: "[StarshipName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EpisodeCharacter");

            migrationBuilder.DropTable(
                name: "Pies");

            migrationBuilder.DropTable(
                name: "StarshipCharacter");

            migrationBuilder.DropTable(
                name: "Episodes");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Starships");

            migrationBuilder.DropTable(
                name: "CharacterGroups");

            migrationBuilder.DropTable(
                name: "CharacterTypes");

            migrationBuilder.DropTable(
                name: "Factions");
        }
    }
}
