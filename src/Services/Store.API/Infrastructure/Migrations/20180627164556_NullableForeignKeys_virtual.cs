using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.API.Infrastructure.Migrations
{
    public partial class NullableForeignKeys_virtual : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreTrack_StoreArtist_ArtistId",
                table: "StoreTrack");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreTrack_StoreGenre_GenreId",
                table: "StoreTrack");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreTrack_StoreArtist_StoreArtistId",
                table: "StoreTrack");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StoreTrack",
                table: "StoreTrack");

            migrationBuilder.RenameTable(
                name: "StoreTrack",
                newName: "StoreVinyl");

            migrationBuilder.RenameIndex(
                name: "IX_StoreTrack_StoreArtistId",
                table: "StoreVinyl",
                newName: "IX_StoreVinyl_StoreArtistId");

            migrationBuilder.RenameIndex(
                name: "IX_StoreTrack_GenreId",
                table: "StoreVinyl",
                newName: "IX_StoreVinyl_GenreId");

            migrationBuilder.RenameIndex(
                name: "IX_StoreTrack_ArtistId",
                table: "StoreVinyl",
                newName: "IX_StoreVinyl_ArtistId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StoreVinyl",
                table: "StoreVinyl",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreVinyl_StoreArtist_ArtistId",
                table: "StoreVinyl",
                column: "ArtistId",
                principalTable: "StoreArtist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreVinyl_StoreGenre_GenreId",
                table: "StoreVinyl",
                column: "GenreId",
                principalTable: "StoreGenre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreVinyl_StoreArtist_StoreArtistId",
                table: "StoreVinyl",
                column: "StoreArtistId",
                principalTable: "StoreArtist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreVinyl_StoreArtist_ArtistId",
                table: "StoreVinyl");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreVinyl_StoreGenre_GenreId",
                table: "StoreVinyl");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreVinyl_StoreArtist_StoreArtistId",
                table: "StoreVinyl");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StoreVinyl",
                table: "StoreVinyl");

            migrationBuilder.RenameTable(
                name: "StoreVinyl",
                newName: "StoreTrack");

            migrationBuilder.RenameIndex(
                name: "IX_StoreVinyl_StoreArtistId",
                table: "StoreTrack",
                newName: "IX_StoreTrack_StoreArtistId");

            migrationBuilder.RenameIndex(
                name: "IX_StoreVinyl_GenreId",
                table: "StoreTrack",
                newName: "IX_StoreTrack_GenreId");

            migrationBuilder.RenameIndex(
                name: "IX_StoreVinyl_ArtistId",
                table: "StoreTrack",
                newName: "IX_StoreTrack_ArtistId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StoreTrack",
                table: "StoreTrack",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreTrack_StoreArtist_ArtistId",
                table: "StoreTrack",
                column: "ArtistId",
                principalTable: "StoreArtist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreTrack_StoreGenre_GenreId",
                table: "StoreTrack",
                column: "GenreId",
                principalTable: "StoreGenre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreTrack_StoreArtist_StoreArtistId",
                table: "StoreTrack",
                column: "StoreArtistId",
                principalTable: "StoreArtist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
