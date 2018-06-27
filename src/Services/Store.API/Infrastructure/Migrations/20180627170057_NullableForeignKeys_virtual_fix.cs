using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.API.Infrastructure.Migrations
{
    public partial class NullableForeignKeys_virtual_fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreVinyl_StoreGenre_GenreId",
                table: "StoreVinyl");

            migrationBuilder.AlterColumn<int>(
                name: "GenreId",
                table: "StoreVinyl",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreVinyl_StoreGenre_GenreId",
                table: "StoreVinyl",
                column: "GenreId",
                principalTable: "StoreGenre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreVinyl_StoreGenre_GenreId",
                table: "StoreVinyl");

            migrationBuilder.AlterColumn<int>(
                name: "GenreId",
                table: "StoreVinyl",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_StoreVinyl_StoreGenre_GenreId",
                table: "StoreVinyl",
                column: "GenreId",
                principalTable: "StoreGenre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
