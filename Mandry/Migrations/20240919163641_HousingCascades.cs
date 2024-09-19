using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mandry.Migrations
{
    /// <inheritdoc />
    public partial class HousingCascades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeatureHousings_Housings_HousingId",
                table: "FeatureHousings");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Housings_HousingToId",
                table: "Reviews");

            migrationBuilder.AddForeignKey(
                name: "FK_FeatureHousings_Housings_HousingId",
                table: "FeatureHousings",
                column: "HousingId",
                principalTable: "Housings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Housings_HousingToId",
                table: "Reviews",
                column: "HousingToId",
                principalTable: "Housings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeatureHousings_Housings_HousingId",
                table: "FeatureHousings");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Housings_HousingToId",
                table: "Reviews");

            migrationBuilder.AddForeignKey(
                name: "FK_FeatureHousings_Housings_HousingId",
                table: "FeatureHousings",
                column: "HousingId",
                principalTable: "Housings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Housings_HousingToId",
                table: "Reviews",
                column: "HousingToId",
                principalTable: "Housings",
                principalColumn: "Id");
        }
    }
}
