using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mandry.Migrations
{
    /// <inheritdoc />
    public partial class Favourites : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Housings_Users_OwnerId",
                table: "Housings");

            migrationBuilder.AlterColumn<Guid>(
                name: "OwnerId",
                table: "Housings",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.CreateTable(
                name: "HousingUser",
                columns: table => new
                {
                    FavouriteToId = table.Column<Guid>(type: "uuid", nullable: false),
                    FavouritesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HousingUser", x => new { x.FavouriteToId, x.FavouritesId });
                    table.ForeignKey(
                        name: "FK_HousingUser_Housings_FavouritesId",
                        column: x => x.FavouritesId,
                        principalTable: "Housings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HousingUser_Users_FavouriteToId",
                        column: x => x.FavouriteToId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HousingUser_FavouritesId",
                table: "HousingUser",
                column: "FavouritesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Housings_Users_OwnerId",
                table: "Housings",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Housings_Users_OwnerId",
                table: "Housings");

            migrationBuilder.DropTable(
                name: "HousingUser");

            migrationBuilder.AlterColumn<Guid>(
                name: "OwnerId",
                table: "Housings",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Housings_Users_OwnerId",
                table: "Housings",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
