using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace manga_project.Migrations
{
    /// <inheritdoc />
    public partial class AddMangaCharacterTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MangaCharacter",
                columns: table => new
                {
                    MangaCharacterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MangaId = table.Column<int>(type: "int", nullable: false),
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    IsCrossover = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MangaCharacter", x => x.MangaCharacterId);
                    table.ForeignKey(
                        name: "FK_MangaCharacter_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MangaCharacter_Manga_MangaId",
                        column: x => x.MangaId,
                        principalTable: "Manga",
                        principalColumn: "MangaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MangaCharacter_CharacterId",
                table: "MangaCharacter",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_MangaCharacter_MangaId",
                table: "MangaCharacter",
                column: "MangaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MangaCharacter");
        }
    }
}
