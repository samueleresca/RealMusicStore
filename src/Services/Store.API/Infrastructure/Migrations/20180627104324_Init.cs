using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.API.Infrastructure.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                "catalog_artist_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                "catalog_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                "genre_hilo",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                "Genre",
                table => new
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
                "StoreArtist",
                table => new
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
                        "FK_StoreArtist_Genre_GenreId",
                        x => x.GenreId,
                        "Genre",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "StoreTrack",
                table => new
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
                        "FK_StoreTrack_StoreArtist_ArtistId",
                        x => x.ArtistId,
                        "StoreArtist",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_StoreTrack_Genre_GenreId",
                        x => x.GenreId,
                        "Genre",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_StoreTrack_StoreArtist_StoreArtistId",
                        x => x.StoreArtistId,
                        "StoreArtist",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                "IX_StoreArtist_GenreId",
                "StoreArtist",
                "GenreId");

            migrationBuilder.CreateIndex(
                "IX_StoreTrack_ArtistId",
                "StoreTrack",
                "ArtistId");

            migrationBuilder.CreateIndex(
                "IX_StoreTrack_GenreId",
                "StoreTrack",
                "GenreId");

            migrationBuilder.CreateIndex(
                "IX_StoreTrack_StoreArtistId",
                "StoreTrack",
                "StoreArtistId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "StoreTrack");

            migrationBuilder.DropTable(
                "StoreArtist");

            migrationBuilder.DropTable(
                "Genre");

            migrationBuilder.DropSequence(
                "catalog_artist_hilo");

            migrationBuilder.DropSequence(
                "catalog_hilo");

            migrationBuilder.DropSequence(
                "genre_hilo");
        }
    }
}
