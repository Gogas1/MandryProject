using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mandry.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccessbilityFeatures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionKey = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessbilityFeatures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Src = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Translatable",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(34)", maxLength: 34, nullable: false),
                    Category_NameKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCategoryPropertyRequired = table.Column<bool>(type: "bit", nullable: true),
                    CategoryPropertyDescriptionKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryPropertyTranslationsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CategoryDescriptionProperty_DescriptionKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Feature_NameKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAllowPinning = table.Column<bool>(type: "bit", nullable: true),
                    IsRecomended = table.Column<bool>(type: "bit", nullable: true),
                    IsAllowCustomName = table.Column<bool>(type: "bit", nullable: true),
                    IsAllowCustomDescription = table.Column<bool>(type: "bit", nullable: true),
                    IsHouseRule = table.Column<bool>(type: "bit", nullable: true),
                    NameKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DefaultValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeatureId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Translatable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Translatable_Translatable_CategoryPropertyTranslationsId",
                        column: x => x.CategoryPropertyTranslationsId,
                        principalTable: "Translatable",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Translatable_Translatable_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "Translatable",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsOwner = table.Column<bool>(type: "bit", nullable: false),
                    ProfileImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Images_ProfileImageId",
                        column: x => x.ProfileImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Translations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TranslationKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TranslationString = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TranslatableId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Translations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Translations_Translatable_TranslatableId",
                        column: x => x.TranslatableId,
                        principalTable: "Translatable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Housings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PricePerNight = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryProperty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxGuests = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Housings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Housings_Translatable_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Translatable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Housings_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AccessbilityFeaturesHousings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccessnilityFeatureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HousingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessbilityFeaturesHousings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccessbilityFeaturesHousings_AccessbilityFeatures_AccessnilityFeatureId",
                        column: x => x.AccessnilityFeatureId,
                        principalTable: "AccessbilityFeatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccessbilityFeaturesHousings_Housings_HousingId",
                        column: x => x.HousingId,
                        principalTable: "Housings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccessbilityFeaturesHousings_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Availabilities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    From = table.Column<DateTime>(type: "datetime2", nullable: false),
                    To = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HousingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Availabilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Availabilities_Housings_HousingId",
                        column: x => x.HousingId,
                        principalTable: "Housings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Availabilities_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FeatureHousings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FeatureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HousingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatureHousings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeatureHousings_Housings_HousingId",
                        column: x => x.HousingId,
                        principalTable: "Housings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FeatureHousings_Translatable_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "Translatable",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    From = table.Column<DateTime>(type: "datetime2", nullable: false),
                    To = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HousingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Housings_HousingId",
                        column: x => x.HousingId,
                        principalTable: "Housings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Users_GuestId",
                        column: x => x.GuestId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParameterFeatureHousings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParameterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FeatureHousingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParameterFeatureHousings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParameterFeatureHousings_FeatureHousings_FeatureHousingId",
                        column: x => x.FeatureHousingId,
                        principalTable: "FeatureHousings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ParameterFeatureHousings_Translatable_ParameterId",
                        column: x => x.ParameterId,
                        principalTable: "Translatable",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Bedrooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HousingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReservationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bedrooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bedrooms_Housings_HousingId",
                        column: x => x.HousingId,
                        principalTable: "Housings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bedrooms_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bedrooms_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Beds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumberOfPeople = table.Column<int>(type: "int", nullable: false),
                    Width = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Height = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BedroomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Beds_Bedrooms_BedroomId",
                        column: x => x.BedroomId,
                        principalTable: "Bedrooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccessbilityFeaturesHousings_AccessnilityFeatureId",
                table: "AccessbilityFeaturesHousings",
                column: "AccessnilityFeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessbilityFeaturesHousings_HousingId",
                table: "AccessbilityFeaturesHousings",
                column: "HousingId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessbilityFeaturesHousings_ImageId",
                table: "AccessbilityFeaturesHousings",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Availabilities_HousingId",
                table: "Availabilities",
                column: "HousingId");

            migrationBuilder.CreateIndex(
                name: "IX_Availabilities_UserId",
                table: "Availabilities",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Bedrooms_HousingId",
                table: "Bedrooms",
                column: "HousingId");

            migrationBuilder.CreateIndex(
                name: "IX_Bedrooms_ImageId",
                table: "Bedrooms",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Bedrooms_ReservationId",
                table: "Bedrooms",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Beds_BedroomId",
                table: "Beds",
                column: "BedroomId");

            migrationBuilder.CreateIndex(
                name: "IX_FeatureHousings_FeatureId",
                table: "FeatureHousings",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_FeatureHousings_HousingId",
                table: "FeatureHousings",
                column: "HousingId");

            migrationBuilder.CreateIndex(
                name: "IX_Housings_CategoryId",
                table: "Housings",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Housings_OwnerId",
                table: "Housings",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_ParameterFeatureHousings_FeatureHousingId",
                table: "ParameterFeatureHousings",
                column: "FeatureHousingId");

            migrationBuilder.CreateIndex(
                name: "IX_ParameterFeatureHousings_ParameterId",
                table: "ParameterFeatureHousings",
                column: "ParameterId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_GuestId",
                table: "Reservations",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_HousingId",
                table: "Reservations",
                column: "HousingId");

            migrationBuilder.CreateIndex(
                name: "IX_Translatable_CategoryPropertyTranslationsId",
                table: "Translatable",
                column: "CategoryPropertyTranslationsId");

            migrationBuilder.CreateIndex(
                name: "IX_Translatable_FeatureId",
                table: "Translatable",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_Translations_TranslatableId",
                table: "Translations",
                column: "TranslatableId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ProfileImageId",
                table: "Users",
                column: "ProfileImageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessbilityFeaturesHousings");

            migrationBuilder.DropTable(
                name: "Availabilities");

            migrationBuilder.DropTable(
                name: "Beds");

            migrationBuilder.DropTable(
                name: "ParameterFeatureHousings");

            migrationBuilder.DropTable(
                name: "Translations");

            migrationBuilder.DropTable(
                name: "AccessbilityFeatures");

            migrationBuilder.DropTable(
                name: "Bedrooms");

            migrationBuilder.DropTable(
                name: "FeatureHousings");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Housings");

            migrationBuilder.DropTable(
                name: "Translatable");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Images");
        }
    }
}
