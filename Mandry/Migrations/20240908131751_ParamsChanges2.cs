using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mandry.Migrations
{
    /// <inheritdoc />
    public partial class ParamsChanges2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParameterFeatureHousings_Translatable_ParameterId",
                table: "ParameterFeatureHousings");

            migrationBuilder.AddForeignKey(
                name: "FK_ParameterFeatureHousings_Translatable_ParameterId",
                table: "ParameterFeatureHousings",
                column: "ParameterId",
                principalTable: "Translatable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParameterFeatureHousings_Translatable_ParameterId",
                table: "ParameterFeatureHousings");

            migrationBuilder.AddForeignKey(
                name: "FK_ParameterFeatureHousings_Translatable_ParameterId",
                table: "ParameterFeatureHousings",
                column: "ParameterId",
                principalTable: "Translatable",
                principalColumn: "Id");
        }
    }
}
