using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.API.Infrastructure.Migrations
{
    public partial class NullableForeignKeys_virtual_fix_fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreVinyl_StoreArtist_ArtistId",
                table: "StoreVinyl");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreVinyl_StoreGenre_GenreId",
                table: "StoreVinyl");

            migrationBuilder.AlterColumn<int>(
                name: "GenreId",
                table: "StoreVinyl",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ArtistId",
                table: "StoreVinyl",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_StoreVinyl_StoreArtist_ArtistId",
                table: "StoreVinyl",
                column: "ArtistId",
                principalTable: "StoreArtist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreVinyl_StoreGenre_GenreId",
                table: "StoreVinyl",
                column: "GenreId",
                principalTable: "StoreGenre",
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

            migrationBuilder.AlterColumn<int>(
                name: "GenreId",
                table: "StoreVinyl",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ArtistId",
                table: "StoreVinyl",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

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
                onDelete: ReferentialAction.Cascade);
        }
    }
}
