using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.API.Infrastructure.Migrations
{
    public partial class NullableForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_StoreArtist_Genre_GenreId",
                "StoreArtist");

            migrationBuilder.DropForeignKey(
                "FK_StoreTrack_Genre_GenreId",
                "StoreTrack");

            migrationBuilder.DropPrimaryKey(
                "PK_Genre",
                "Genre");

            migrationBuilder.RenameTable(
                "Genre",
                newName: "StoreGenre");

            migrationBuilder.AlterColumn<int>(
                "GenreId",
                "StoreTrack",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                "PK_StoreGenre",
                "StoreGenre",
                "Id");

            migrationBuilder.AddForeignKey(
                "FK_StoreArtist_StoreGenre_GenreId",
                "StoreArtist",
                "GenreId",
                "StoreGenre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                "FK_StoreTrack_StoreGenre_GenreId",
                "StoreTrack",
                "GenreId",
                "StoreGenre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_StoreArtist_StoreGenre_GenreId",
                "StoreArtist");

            migrationBuilder.DropForeignKey(
                "FK_StoreTrack_StoreGenre_GenreId",
                "StoreTrack");

            migrationBuilder.DropPrimaryKey(
                "PK_StoreGenre",
                "StoreGenre");

            migrationBuilder.RenameTable(
                "StoreGenre",
                newName: "Genre");

            migrationBuilder.AlterColumn<int>(
                "GenreId",
                "StoreTrack",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                "PK_Genre",
                "Genre",
                "Id");

            migrationBuilder.AddForeignKey(
                "FK_StoreArtist_Genre_GenreId",
                "StoreArtist",
                "GenreId",
                "Genre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                "FK_StoreTrack_Genre_GenreId",
                "StoreTrack",
                "GenreId",
                "Genre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
