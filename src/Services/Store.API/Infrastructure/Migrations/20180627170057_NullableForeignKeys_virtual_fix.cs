using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.API.Infrastructure.Migrations
{
    public partial class NullableForeignKeys_virtual_fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_StoreVinyl_StoreGenre_GenreId",
                "StoreVinyl");

            migrationBuilder.AlterColumn<int>(
                "GenreId",
                "StoreVinyl",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                "FK_StoreVinyl_StoreGenre_GenreId",
                "StoreVinyl",
                "GenreId",
                "StoreGenre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_StoreVinyl_StoreGenre_GenreId",
                "StoreVinyl");

            migrationBuilder.AlterColumn<int>(
                "GenreId",
                "StoreVinyl",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                "FK_StoreVinyl_StoreGenre_GenreId",
                "StoreVinyl",
                "GenreId",
                "StoreGenre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
