﻿// <auto-generated />
using System;
using Mandry.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Mandry.Migrations
{
    [DbContext(typeof(MandryDbContext))]
    partial class MandryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Mandry.Models.DB.AccessbilityFeature", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("DescriptionKey")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NameKey")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("AccessbilityFeatures");
                });

            modelBuilder.Entity("Mandry.Models.DB.AccessbilityFeatureHousing", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AccessnilityFeatureId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("HousingId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ImageId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AccessnilityFeatureId");

                    b.HasIndex("HousingId");

                    b.HasIndex("ImageId");

                    b.ToTable("AccessbilityFeaturesHousings");
                });

            modelBuilder.Entity("Mandry.Models.DB.Availability", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("From")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("HousingId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("To")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("HousingId");

                    b.HasIndex("UserId");

                    b.ToTable("Availabilities");
                });

            modelBuilder.Entity("Mandry.Models.DB.Bed", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BedroomId")
                        .HasColumnType("uuid");

                    b.Property<string>("Height")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("NumberOfPeople")
                        .HasColumnType("integer");

                    b.Property<string>("Width")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BedroomId");

                    b.ToTable("Beds");
                });

            modelBuilder.Entity("Mandry.Models.DB.Bedroom", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("HousingId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ImageId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ReservationId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("HousingId");

                    b.HasIndex("ImageId");

                    b.HasIndex("ReservationId");

                    b.ToTable("Bedrooms");
                });

            modelBuilder.Entity("Mandry.Models.DB.FeatureHousing", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CustomDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CustomName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("FeatureId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("HousingId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("FeatureId");

                    b.HasIndex("HousingId");

                    b.ToTable("FeatureHousings");
                });

            modelBuilder.Entity("Mandry.Models.DB.Housing", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<string>("CategoryProperty")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("MaxGuests")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("PricePerNight")
                        .HasPrecision(18, 2)
                        .HasColumnType("numeric(18,2)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Housings");
                });

            modelBuilder.Entity("Mandry.Models.DB.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Src")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("Mandry.Models.DB.ParameterFeatureHousing", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("FeatureHousingId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ParameterId")
                        .HasColumnType("uuid");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("FeatureHousingId");

                    b.HasIndex("ParameterId");

                    b.ToTable("ParameterFeatureHousings");
                });

            modelBuilder.Entity("Mandry.Models.DB.Reservation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("From")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("GuestId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("HousingId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("To")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("GuestId");

                    b.HasIndex("HousingId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("Mandry.Models.DB.Translation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("TranslatableId")
                        .HasColumnType("uuid");

                    b.Property<string>("TranslationKey")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TranslationString")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("TranslatableId");

                    b.ToTable("Translations");
                });

            modelBuilder.Entity("Mandry.Models.DB.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool>("IsAgreementAccepted")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsOwner")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<Guid?>("ProfileImageId")
                        .HasColumnType("uuid");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ProfileImageId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Mandry.Models.Inheritance.Translatable", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(34)
                        .HasColumnType("character varying(34)");

                    b.HasKey("Id");

                    b.ToTable("Translatable");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Translatable");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Mandry.Models.DB.Category", b =>
                {
                    b.HasBaseType("Mandry.Models.Inheritance.Translatable");

                    b.Property<string>("CategoryPropertyDescriptionKey")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("CategoryPropertyTranslationsId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsCategoryPropertyRequired")
                        .HasColumnType("boolean");

                    b.Property<string>("NameKey")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasIndex("CategoryPropertyTranslationsId");

                    b.ToTable("Translatable", t =>
                        {
                            t.Property("NameKey")
                                .HasColumnName("Category_NameKey");
                        });

                    b.HasDiscriminator().HasValue("Category");
                });

            modelBuilder.Entity("Mandry.Models.DB.CategoryDescriptionProperty", b =>
                {
                    b.HasBaseType("Mandry.Models.Inheritance.Translatable");

                    b.Property<string>("DescriptionKey")
                        .IsRequired()
                        .HasColumnType("text");

                    b.ToTable("Translatable", t =>
                        {
                            t.Property("DescriptionKey")
                                .HasColumnName("CategoryDescriptionProperty_DescriptionKey");
                        });

                    b.HasDiscriminator().HasValue("CategoryDescriptionProperty");
                });

            modelBuilder.Entity("Mandry.Models.DB.Feature", b =>
                {
                    b.HasBaseType("Mandry.Models.Inheritance.Translatable");

                    b.Property<string>("DescriptionKey")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsAllowCustomDescription")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsAllowCustomName")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsAllowPinning")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsHouseRule")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsRecomended")
                        .HasColumnType("boolean");

                    b.Property<string>("NameKey")
                        .IsRequired()
                        .HasColumnType("text");

                    b.ToTable("Translatable", t =>
                        {
                            t.Property("NameKey")
                                .HasColumnName("Feature_NameKey");
                        });

                    b.HasDiscriminator().HasValue("Feature");
                });

            modelBuilder.Entity("Mandry.Models.DB.Parameter", b =>
                {
                    b.HasBaseType("Mandry.Models.Inheritance.Translatable");

                    b.Property<string>("DefaultValue")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("FeatureId")
                        .HasColumnType("uuid");

                    b.Property<string>("NameKey")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasIndex("FeatureId");

                    b.HasDiscriminator().HasValue("Parameter");
                });

            modelBuilder.Entity("Mandry.Models.DB.AccessbilityFeatureHousing", b =>
                {
                    b.HasOne("Mandry.Models.DB.AccessbilityFeature", "AccessnilityFeature")
                        .WithMany("AccessbilityFeatureHousings")
                        .HasForeignKey("AccessnilityFeatureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mandry.Models.DB.Housing", "Housing")
                        .WithMany("AccessbilitiyFeatureHousings")
                        .HasForeignKey("HousingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mandry.Models.DB.Image", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId");

                    b.Navigation("AccessnilityFeature");

                    b.Navigation("Housing");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("Mandry.Models.DB.Availability", b =>
                {
                    b.HasOne("Mandry.Models.DB.Housing", "Housing")
                        .WithMany("Availabilities")
                        .HasForeignKey("HousingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mandry.Models.DB.User", null)
                        .WithMany("Availability")
                        .HasForeignKey("UserId");

                    b.Navigation("Housing");
                });

            modelBuilder.Entity("Mandry.Models.DB.Bed", b =>
                {
                    b.HasOne("Mandry.Models.DB.Bedroom", "Bedroom")
                        .WithMany("Beds")
                        .HasForeignKey("BedroomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bedroom");
                });

            modelBuilder.Entity("Mandry.Models.DB.Bedroom", b =>
                {
                    b.HasOne("Mandry.Models.DB.Housing", "Housing")
                        .WithMany("Bedrooms")
                        .HasForeignKey("HousingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mandry.Models.DB.Image", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mandry.Models.DB.Reservation", null)
                        .WithMany("Bedrooms")
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Housing");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("Mandry.Models.DB.FeatureHousing", b =>
                {
                    b.HasOne("Mandry.Models.DB.Feature", "Feature")
                        .WithMany("FeatureHousing")
                        .HasForeignKey("FeatureId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Mandry.Models.DB.Housing", "Housing")
                        .WithMany("FeatureHousings")
                        .HasForeignKey("HousingId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Feature");

                    b.Navigation("Housing");
                });

            modelBuilder.Entity("Mandry.Models.DB.Housing", b =>
                {
                    b.HasOne("Mandry.Models.DB.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mandry.Models.DB.User", "Owner")
                        .WithMany("Housings")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Mandry.Models.DB.ParameterFeatureHousing", b =>
                {
                    b.HasOne("Mandry.Models.DB.FeatureHousing", "FeatureHousing")
                        .WithMany("ParametersValues")
                        .HasForeignKey("FeatureHousingId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Mandry.Models.DB.Parameter", "Parameter")
                        .WithMany("ParameterValuesForHousing")
                        .HasForeignKey("ParameterId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("FeatureHousing");

                    b.Navigation("Parameter");
                });

            modelBuilder.Entity("Mandry.Models.DB.Reservation", b =>
                {
                    b.HasOne("Mandry.Models.DB.User", "Guest")
                        .WithMany("Reservations")
                        .HasForeignKey("GuestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mandry.Models.DB.Housing", "Housing")
                        .WithMany("Reservations")
                        .HasForeignKey("HousingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guest");

                    b.Navigation("Housing");
                });

            modelBuilder.Entity("Mandry.Models.DB.Translation", b =>
                {
                    b.HasOne("Mandry.Models.Inheritance.Translatable", "Translatable")
                        .WithMany("Translation")
                        .HasForeignKey("TranslatableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Translatable");
                });

            modelBuilder.Entity("Mandry.Models.DB.User", b =>
                {
                    b.HasOne("Mandry.Models.DB.Image", "ProfileImage")
                        .WithMany()
                        .HasForeignKey("ProfileImageId");

                    b.Navigation("ProfileImage");
                });

            modelBuilder.Entity("Mandry.Models.DB.Category", b =>
                {
                    b.HasOne("Mandry.Models.DB.CategoryDescriptionProperty", "CategoryPropertyTranslations")
                        .WithMany()
                        .HasForeignKey("CategoryPropertyTranslationsId");

                    b.Navigation("CategoryPropertyTranslations");
                });

            modelBuilder.Entity("Mandry.Models.DB.Parameter", b =>
                {
                    b.HasOne("Mandry.Models.DB.Feature", "Feature")
                        .WithMany("Parameters")
                        .HasForeignKey("FeatureId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Feature");
                });

            modelBuilder.Entity("Mandry.Models.DB.AccessbilityFeature", b =>
                {
                    b.Navigation("AccessbilityFeatureHousings");
                });

            modelBuilder.Entity("Mandry.Models.DB.Bedroom", b =>
                {
                    b.Navigation("Beds");
                });

            modelBuilder.Entity("Mandry.Models.DB.FeatureHousing", b =>
                {
                    b.Navigation("ParametersValues");
                });

            modelBuilder.Entity("Mandry.Models.DB.Housing", b =>
                {
                    b.Navigation("AccessbilitiyFeatureHousings");

                    b.Navigation("Availabilities");

                    b.Navigation("Bedrooms");

                    b.Navigation("FeatureHousings");

                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("Mandry.Models.DB.Reservation", b =>
                {
                    b.Navigation("Bedrooms");
                });

            modelBuilder.Entity("Mandry.Models.DB.User", b =>
                {
                    b.Navigation("Availability");

                    b.Navigation("Housings");

                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("Mandry.Models.Inheritance.Translatable", b =>
                {
                    b.Navigation("Translation");
                });

            modelBuilder.Entity("Mandry.Models.DB.Feature", b =>
                {
                    b.Navigation("FeatureHousing");

                    b.Navigation("Parameters");
                });

            modelBuilder.Entity("Mandry.Models.DB.Parameter", b =>
                {
                    b.Navigation("ParameterValuesForHousing");
                });
#pragma warning restore 612, 618
        }
    }
}
