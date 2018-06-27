using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.API.Infrastructure.Migrations
{
    public partial class NullableForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreArtist_Genre_GenreId",
                table: "StoreArtist");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreTrack_Genre_GenreId",
                table: "StoreTrack");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genre",
                table: "Genre");

            migrationBuilder.RenameTable(
                name: "Genre",
                newName: "StoreGenre");

            migrationBuilder.AlterColumn<int>(
                name: "GenreId",
                table: "StoreTrack",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_StoreGenre",
                table: "StoreGenre",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreArtist_StoreGenre_GenreId",
                table: "StoreArtist",
                column: "GenreId",
                principalTable: "StoreGenre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreTrack_StoreGenre_GenreId",
                table: "StoreTrack",
                column: "GenreId",
                principalTable: "StoreGenre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreArtist_StoreGenre_GenreId",
                table: "StoreArtist");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreTrack_StoreGenre_GenreId",
                table: "StoreTrack");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StoreGenre",
                table: "StoreGenre");

            migrationBuilder.RenameTable(
                name: "StoreGenre",
                newName: "Genre");

            migrationBuilder.AlterColumn<int>(
                name: "GenreId",
                table: "StoreTrack",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genre",
                table: "Genre",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreArtist_Genre_GenreId",
                table: "StoreArtist",
                column: "GenreId",
                principalTable: "Genre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreTrack_Genre_GenreId",
                table: "StoreTrack",
                column: "GenreId",
                principalTable: "Genre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
