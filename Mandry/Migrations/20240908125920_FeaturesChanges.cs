using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mandry.Migrations
{
    /// <inheritdoc />
    public partial class FeaturesChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Translatable_Translatable_CounterFeatureId",
                table: "Translatable");

            migrationBuilder.AddForeignKey(
                name: "FK_Translatable_Translatable_CounterFeatureId",
                table: "Translatable",
                column: "CounterFeatureId",
                principalTable: "Translatable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Translatable_Translatable_CounterFeatureId",
                table: "Translatable");

            migrationBuilder.AddForeignKey(
                name: "FK_Translatable_Translatable_CounterFeatureId",
                table: "Translatable",
                column: "CounterFeatureId",
                principalTable: "Translatable",
                principalColumn: "Id");
        }
    }
}
