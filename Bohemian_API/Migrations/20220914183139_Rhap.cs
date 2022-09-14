using Microsoft.EntityFrameworkCore.Migrations;

namespace Bohemian_API.Migrations
{
    public partial class Rhap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Artist_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Artist_Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Artist_Id);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Genre_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Genre_Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Genre_Id);
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    Album_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Album_Title = table.Column<string>(nullable: true),
                    Artist_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Album_Id);
                    table.ForeignKey(
                        name: "FK_Albums_Artists_Artist_Id",
                        column: x => x.Artist_Id,
                        principalTable: "Artists",
                        principalColumn: "Artist_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    Song_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Song_Title = table.Column<string>(nullable: true),
                    Song_Length = table.Column<string>(nullable: true),
                    Album_Id = table.Column<int>(nullable: false),
                    Genre_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.Song_Id);
                    table.ForeignKey(
                        name: "FK_Songs_Albums_Album_Id",
                        column: x => x.Album_Id,
                        principalTable: "Albums",
                        principalColumn: "Album_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Songs_Genre_Genre_Id",
                        column: x => x.Genre_Id,
                        principalTable: "Genre",
                        principalColumn: "Genre_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_Artist_Id",
                table: "Albums",
                column: "Artist_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_Album_Id",
                table: "Songs",
                column: "Album_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_Genre_Id",
                table: "Songs",
                column: "Genre_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Artists");
        }
    }
}
