using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.API.Infrastructure.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "catalog_artist_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "catalog_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "genre_hilo",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StoreArtist",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    ArtistName = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsDisabled = table.Column<bool>(nullable: false),
                    GenreId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreArtist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreArtist_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StoreTrack",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    ArtistId = table.Column<int>(nullable: false),
                    GenreId = table.Column<int>(nullable: false),
                    AvailableStock = table.Column<int>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    StoreArtistId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreTrack", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreTrack_StoreArtist_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "StoreArtist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StoreTrack_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StoreTrack_StoreArtist_StoreArtistId",
                        column: x => x.StoreArtistId,
                        principalTable: "StoreArtist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StoreArtist_GenreId",
                table: "StoreArtist",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreTrack_ArtistId",
                table: "StoreTrack",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreTrack_GenreId",
                table: "StoreTrack",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreTrack_StoreArtistId",
                table: "StoreTrack",
                column: "StoreArtistId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StoreTrack");

            migrationBuilder.DropTable(
                name: "StoreArtist");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropSequence(
                name: "catalog_artist_hilo");

            migrationBuilder.DropSequence(
                name: "catalog_hilo");

            migrationBuilder.DropSequence(
                name: "genre_hilo");
        }
    }
}
