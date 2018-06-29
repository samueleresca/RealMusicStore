using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.API.Infrastructure.Migrations
{
    public partial class NullableForeignKeys_virtual_fix_fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_StoreVinyl_StoreArtist_ArtistId",
                "StoreVinyl");

            migrationBuilder.DropForeignKey(
                "FK_StoreVinyl_StoreGenre_GenreId",
                "StoreVinyl");

            migrationBuilder.AlterColumn<int>(
                "GenreId",
                "StoreVinyl",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                "ArtistId",
                "StoreVinyl",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                "FK_StoreVinyl_StoreArtist_ArtistId",
                "StoreVinyl",
                "ArtistId",
                "StoreArtist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                "FK_StoreVinyl_StoreGenre_GenreId",
                "StoreVinyl",
                "GenreId",
                "StoreGenre",
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

            migrationBuilder.AlterColumn<int>(
                "GenreId",
                "StoreVinyl",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                "ArtistId",
                "StoreVinyl",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

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
                onDelete: ReferentialAction.Cascade);
        }
    }
}
