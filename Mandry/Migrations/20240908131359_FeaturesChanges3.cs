using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mandry.Migrations
{
    /// <inheritdoc />
    public partial class FeaturesChanges3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeatureHousings_Translatable_FeatureId",
                table: "FeatureHousings");

            migrationBuilder.DropForeignKey(
                name: "FK_ParameterFeatureHousings_FeatureHousings_FeatureHousingId",
                table: "ParameterFeatureHousings");

            migrationBuilder.AddForeignKey(
                name: "FK_FeatureHousings_Translatable_FeatureId",
                table: "FeatureHousings",
                column: "FeatureId",
                principalTable: "Translatable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ParameterFeatureHousings_FeatureHousings_FeatureHousingId",
                table: "ParameterFeatureHousings",
                column: "FeatureHousingId",
                principalTable: "FeatureHousings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeatureHousings_Translatable_FeatureId",
                table: "FeatureHousings");

            migrationBuilder.DropForeignKey(
                name: "FK_ParameterFeatureHousings_FeatureHousings_FeatureHousingId",
                table: "ParameterFeatureHousings");

            migrationBuilder.AddForeignKey(
                name: "FK_FeatureHousings_Translatable_FeatureId",
                table: "FeatureHousings",
                column: "FeatureId",
                principalTable: "Translatable",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ParameterFeatureHousings_FeatureHousings_FeatureHousingId",
                table: "ParameterFeatureHousings",
                column: "FeatureHousingId",
                principalTable: "FeatureHousings",
                principalColumn: "Id");
        }
    }
}
