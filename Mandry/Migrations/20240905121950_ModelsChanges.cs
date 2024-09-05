using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mandry.Migrations
{
    /// <inheritdoc />
    public partial class ModelsChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FeatureIcon",
                table: "Translatable",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Bedrooms",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FeatureIcon",
                table: "Translatable");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Bedrooms");
        }
    }
}
