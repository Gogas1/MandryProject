using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mandry.Migrations
{
    /// <inheritdoc />
    public partial class FeaturesChanges2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Translatable_Translatable_FeatureId",
                table: "Translatable");

            migrationBuilder.AddForeignKey(
                name: "FK_Translatable_Translatable_FeatureId",
                table: "Translatable",
                column: "FeatureId",
                principalTable: "Translatable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Translatable_Translatable_FeatureId",
                table: "Translatable");

            migrationBuilder.AddForeignKey(
                name: "FK_Translatable_Translatable_FeatureId",
                table: "Translatable",
                column: "FeatureId",
                principalTable: "Translatable",
                principalColumn: "Id");
        }
    }
}
