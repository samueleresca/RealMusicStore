using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.API.Infrastructure.Migrations
{
    public partial class NullableForeignKeys_virtual : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_StoreTrack_StoreArtist_ArtistId",
                "StoreTrack");

            migrationBuilder.DropForeignKey(
                "FK_StoreTrack_StoreGenre_GenreId",
                "StoreTrack");

            migrationBuilder.DropForeignKey(
                "FK_StoreTrack_StoreArtist_StoreArtistId",
                "StoreTrack");

            migrationBuilder.DropPrimaryKey(
                "PK_StoreTrack",
                "StoreTrack");

            migrationBuilder.RenameTable(
                "StoreTrack",
                newName: "StoreVinyl");

            migrationBuilder.RenameIndex(
                "IX_StoreTrack_StoreArtistId",
                table: "StoreVinyl",
                newName: "IX_StoreVinyl_StoreArtistId");

            migrationBuilder.RenameIndex(
                "IX_StoreTrack_GenreId",
                table: "StoreVinyl",
                newName: "IX_StoreVinyl_GenreId");

            migrationBuilder.RenameIndex(
                "IX_StoreTrack_ArtistId",
                table: "StoreVinyl",
                newName: "IX_StoreVinyl_ArtistId");

            migrationBuilder.AddPrimaryKey(
                "PK_StoreVinyl",
                "StoreVinyl",
                "Id");

            migrationBuilder.AddForeignKey(
                "FK_StoreVinyl_StoreArtist_ArtistId",
                "StoreVinyl",
                "ArtistId",
                "StoreArtist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                "FK_StoreVinyl_StoreGenre_GenreId",
                "StoreVinyl",
                "GenreId",
                "StoreGenre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                "FK_StoreVinyl_StoreArtist_StoreArtistId",
                "StoreVinyl",
                "StoreArtistId",
                "StoreArtist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_StoreVinyl_StoreArtist_ArtistId",
                "StoreVinyl");

            migrationBuilder.DropForeignKey(
                "FK_StoreVinyl_StoreGenre_GenreId",
                "StoreVinyl");

            migrationBuilder.DropForeignKey(
                "FK_StoreVinyl_StoreArtist_StoreArtistId",
                "StoreVinyl");

            migrationBuilder.DropPrimaryKey(
                "PK_StoreVinyl",
                "StoreVinyl");

            migrationBuilder.RenameTable(
                "StoreVinyl",
                newName: "StoreTrack");

            migrationBuilder.RenameIndex(
                "IX_StoreVinyl_StoreArtistId",
                table: "StoreTrack",
                newName: "IX_StoreTrack_StoreArtistId");

            migrationBuilder.RenameIndex(
                "IX_StoreVinyl_GenreId",
                table: "StoreTrack",
                newName: "IX_StoreTrack_GenreId");

            migrationBuilder.RenameIndex(
                "IX_StoreVinyl_ArtistId",
                table: "StoreTrack",
                newName: "IX_StoreTrack_ArtistId");

            migrationBuilder.AddPrimaryKey(
                "PK_StoreTrack",
                "StoreTrack",
                "Id");

            migrationBuilder.AddForeignKey(
                "FK_StoreTrack_StoreArtist_ArtistId",
                "StoreTrack",
                "ArtistId",
                "StoreArtist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                "FK_StoreTrack_StoreGenre_GenreId",
                "StoreTrack",
                "GenreId",
                "StoreGenre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                "FK_StoreTrack_StoreArtist_StoreArtistId",
                "StoreTrack",
                "StoreArtistId",
                "StoreArtist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
