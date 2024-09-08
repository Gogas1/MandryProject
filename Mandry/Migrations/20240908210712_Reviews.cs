using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mandry.Migrations
{
    /// <inheritdoc />
    public partial class Reviews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "AverageRating",
                table: "Users",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<DateTime>(
                name: "OwnerFrom",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<float>(
                name: "AverageRating",
                table: "Housings",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FromId = table.Column<Guid>(type: "uuid", nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
                    ToId = table.Column<Guid>(type: "uuid", nullable: false),
                    HousingToId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Housings_HousingToId",
                        column: x => x.HousingToId,
                        principalTable: "Housings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reviews_Users_FromId",
                        column: x => x.FromId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reviews_Users_ToId",
                        column: x => x.ToId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_FromId",
                table: "Reviews",
                column: "FromId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_HousingToId",
                table: "Reviews",
                column: "HousingToId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ToId",
                table: "Reviews",
                column: "ToId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropColumn(
                name: "AverageRating",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "OwnerFrom",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AverageRating",
                table: "Housings");
        }
    }
}
