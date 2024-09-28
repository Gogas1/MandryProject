﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mandry.Migrations
{
    /// <inheritdoc />
    public partial class UserAbout : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserAbout",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Education = table.Column<string>(type: "text", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    Birthday = table.Column<string>(type: "text", nullable: false),
                    Hobby = table.Column<string>(type: "text", nullable: false),
                    Skills = table.Column<string>(type: "text", nullable: false),
                    TimeThings = table.Column<string>(type: "text", nullable: false),
                    Profession = table.Column<string>(type: "text", nullable: false),
                    Languages = table.Column<string>(type: "text", nullable: false),
                    Song = table.Column<string>(type: "text", nullable: false),
                    Fact = table.Column<string>(type: "text", nullable: false),
                    Biography = table.Column<string>(type: "text", nullable: false),
                    Pets = table.Column<string>(type: "text", nullable: false),
                    AboutMe = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAbout", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAbout_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAbout_UserId",
                table: "UserAbout",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAbout");
        }
    }
}