using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mandry.Migrations
{
    /// <inheritdoc />
    public partial class ImagesChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Bedrooms");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Housings",
                newName: "ShortDescription");

            migrationBuilder.AddColumn<Guid>(
                name: "FeatureImageId",
                table: "Translatable",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TypeKey",
                table: "Translatable",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "HousingId",
                table: "Images",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Bathrooms",
                table: "Housings",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LocationCoords",
                table: "Housings",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LocationCountry",
                table: "Housings",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LocationPlace",
                table: "Housings",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Translatable_FeatureImageId",
                table: "Translatable",
                column: "FeatureImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_HousingId",
                table: "Images",
                column: "HousingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Housings_HousingId",
                table: "Images",
                column: "HousingId",
                principalTable: "Housings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Translatable_Images_FeatureImageId",
                table: "Translatable",
                column: "FeatureImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Housings_HousingId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Translatable_Images_FeatureImageId",
                table: "Translatable");

            migrationBuilder.DropIndex(
                name: "IX_Translatable_FeatureImageId",
                table: "Translatable");

            migrationBuilder.DropIndex(
                name: "IX_Images_HousingId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "FeatureImageId",
                table: "Translatable");

            migrationBuilder.DropColumn(
                name: "TypeKey",
                table: "Translatable");

            migrationBuilder.DropColumn(
                name: "HousingId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Bathrooms",
                table: "Housings");

            migrationBuilder.DropColumn(
                name: "LocationCoords",
                table: "Housings");

            migrationBuilder.DropColumn(
                name: "LocationCountry",
                table: "Housings");

            migrationBuilder.DropColumn(
                name: "LocationPlace",
                table: "Housings");

            migrationBuilder.RenameColumn(
                name: "ShortDescription",
                table: "Housings",
                newName: "Location");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Bedrooms",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
