using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mandry.Migrations
{
    /// <inheritdoc />
    public partial class Changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CounterFeatureId",
                table: "Translatable",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCounterFeature",
                table: "Translatable",
                type: "boolean",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Translatable_CounterFeatureId",
                table: "Translatable",
                column: "CounterFeatureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Translatable_Translatable_CounterFeatureId",
                table: "Translatable",
                column: "CounterFeatureId",
                principalTable: "Translatable",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Translatable_Translatable_CounterFeatureId",
                table: "Translatable");

            migrationBuilder.DropIndex(
                name: "IX_Translatable_CounterFeatureId",
                table: "Translatable");

            migrationBuilder.DropColumn(
                name: "CounterFeatureId",
                table: "Translatable");

            migrationBuilder.DropColumn(
                name: "IsCounterFeature",
                table: "Translatable");
        }
    }
}
