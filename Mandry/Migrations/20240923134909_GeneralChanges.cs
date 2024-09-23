using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mandry.Migrations
{
    /// <inheritdoc />
    public partial class GeneralChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bedrooms_Reservations_ReservationId",
                table: "Bedrooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Housings_HousingId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Bedrooms_ReservationId",
                table: "Bedrooms");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "Bedrooms");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Reservations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Housings_HousingId",
                table: "Images",
                column: "HousingId",
                principalTable: "Housings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Housings_HousingId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Reservations");

            migrationBuilder.AddColumn<Guid>(
                name: "ReservationId",
                table: "Bedrooms",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bedrooms_ReservationId",
                table: "Bedrooms",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bedrooms_Reservations_ReservationId",
                table: "Bedrooms",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Housings_HousingId",
                table: "Images",
                column: "HousingId",
                principalTable: "Housings",
                principalColumn: "Id");
        }
    }
}
