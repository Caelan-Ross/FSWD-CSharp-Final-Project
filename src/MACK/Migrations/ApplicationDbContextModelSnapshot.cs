﻿// <auto-generated />
using System;
using MACK;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MACK.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MACK.Models.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("varchar(2)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("AddressId");

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            AddressId = 1,
                            City = "Prince Albert",
                            Country = "CA",
                            PostalCode = "S6V-2X1",
                            Province = "Saskatchewan",
                            Street = "123 Main Street"
                        },
                        new
                        {
                            AddressId = 2,
                            City = "Prince Albert",
                            Country = "CA",
                            PostalCode = "S6V-3Y2",
                            Province = "Saskatchewan",
                            Street = "456 Secondary Road"
                        });
                });

            modelBuilder.Entity("MACK.Models.Colour", b =>
                {
                    b.Property<int>("ColourId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ColourName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("ColourId");

                    b.HasIndex("ColourName")
                        .IsUnique();

                    b.ToTable("Colours");

                    b.HasData(
                        new
                        {
                            ColourId = 1,
                            ColourName = "Red"
                        },
                        new
                        {
                            ColourId = 2,
                            ColourName = "Black"
                        });
                });

            modelBuilder.Entity("MACK.Models.Condition", b =>
                {
                    b.Property<int>("ConditionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ConditionName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("ConditionId");

                    b.HasIndex("ConditionName")
                        .IsUnique();

                    b.ToTable("Conditions");

                    b.HasData(
                        new
                        {
                            ConditionId = 1,
                            ConditionName = "Used"
                        });
                });

            modelBuilder.Entity("MACK.Models.Corporation", b =>
                {
                    b.Property<int>("CorporationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("CorporationName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("CorporationId");

                    b.HasIndex("AddressId");

                    b.HasIndex("CorporationName")
                        .IsUnique();

                    b.ToTable("Corporations");

                    b.HasData(
                        new
                        {
                            CorporationId = 1,
                            AddressId = 1,
                            CorporationName = "AutoGroup Inc."
                        });
                });

            modelBuilder.Entity("MACK.Models.Dealership", b =>
                {
                    b.Property<int>("DealershipId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<int?>("AddressId1")
                        .HasColumnType("int");

                    b.Property<int>("CorporationId")
                        .HasColumnType("int");

                    b.Property<int?>("CorporationId1")
                        .HasColumnType("int");

                    b.Property<string>("DealershipName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("DealershipId");

                    b.HasIndex("AddressId");

                    b.HasIndex("AddressId1");

                    b.HasIndex("CorporationId");

                    b.HasIndex("CorporationId1");

                    b.ToTable("Dealerships");

                    b.HasData(
                        new
                        {
                            DealershipId = 1,
                            AddressId = 2,
                            CorporationId = 1,
                            DealershipName = "Lakeland Ford"
                        });
                });

            modelBuilder.Entity("MACK.Models.Drivetrain", b =>
                {
                    b.Property<int>("DrivetrainId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("DrivetrainType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("DrivetrainId");

                    b.HasIndex("DrivetrainType")
                        .IsUnique();

                    b.ToTable("Drivetrains");

                    b.HasData(
                        new
                        {
                            DrivetrainId = 1,
                            DrivetrainType = "FWD"
                        });
                });

            modelBuilder.Entity("MACK.Models.Manufacturer", b =>
                {
                    b.Property<int>("ManufacturerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ManufacturerName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("ManufacturerId");

                    b.HasIndex("ManufacturerName")
                        .IsUnique();

                    b.ToTable("Manufacturers");

                    b.HasData(
                        new
                        {
                            ManufacturerId = 1,
                            ManufacturerName = "Honda"
                        });
                });

            modelBuilder.Entity("MACK.Models.Model", b =>
                {
                    b.Property<int>("ModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ManufacturerId")
                        .HasColumnType("int");

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("ModelId");

                    b.HasIndex("ManufacturerId");

                    b.HasIndex("ModelName", "ManufacturerId")
                        .IsUnique();

                    b.ToTable("Models");

                    b.HasData(
                        new
                        {
                            ModelId = 1,
                            ManufacturerId = 1,
                            ModelName = "Accord"
                        });
                });

            modelBuilder.Entity("MACK.Models.Series", b =>
                {
                    b.Property<int>("SeriesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ModelId")
                        .HasColumnType("int");

                    b.Property<string>("SeriesName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("SeriesId");

                    b.HasIndex("ModelId");

                    b.HasIndex("SeriesName", "ModelId")
                        .IsUnique();

                    b.ToTable("Series");

                    b.HasData(
                        new
                        {
                            SeriesId = 1,
                            ModelId = 1,
                            SeriesName = "LX"
                        });
                });

            modelBuilder.Entity("MACK.Models.Transmission", b =>
                {
                    b.Property<int>("TransmissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("TransmissionGears")
                        .HasColumnType("int");

                    b.Property<string>("TransmissionType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("TransmissionId");

                    b.HasIndex("TransmissionType")
                        .IsUnique();

                    b.ToTable("Transmissions");

                    b.HasData(
                        new
                        {
                            TransmissionId = 1,
                            TransmissionGears = 6,
                            TransmissionType = "Automatic"
                        });
                });

            modelBuilder.Entity("MACK.Models.Vehicle", b =>
                {
                    b.Property<string>("VIN")
                        .HasMaxLength(17)
                        .HasColumnType("varchar(17)");

                    b.Property<int>("BodyDoorCount")
                        .HasColumnType("int");

                    b.Property<int>("CityMPG")
                        .HasColumnType("int");

                    b.Property<int>("DrivetrainId")
                        .HasColumnType("int");

                    b.Property<string>("Engine")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("EngineCylinderCount")
                        .HasColumnType("int");

                    b.Property<string>("EngineDisplacement")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<int>("ExteriorColourId")
                        .HasColumnType("int");

                    b.Property<string>("Fuel")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("Height")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("HighwayMPG")
                        .HasColumnType("int");

                    b.Property<int>("InteriorColourId")
                        .HasColumnType("int");

                    b.Property<decimal>("Length")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("ManufacturerId")
                        .HasColumnType("int");

                    b.Property<int>("ModelId")
                        .HasColumnType("int");

                    b.Property<int?>("SeriesId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("TransmissionId")
                        .HasColumnType("int");

                    b.Property<int>("VehicleTypeId")
                        .HasColumnType("int");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Width")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("VIN");

                    b.HasIndex("DrivetrainId");

                    b.HasIndex("ExteriorColourId");

                    b.HasIndex("InteriorColourId");

                    b.HasIndex("ManufacturerId");

                    b.HasIndex("ModelId");

                    b.HasIndex("SeriesId");

                    b.HasIndex("TransmissionId");

                    b.HasIndex("VIN")
                        .IsUnique();

                    b.HasIndex("VehicleTypeId");

                    b.ToTable("Vehicles");

                    b.HasData(
                        new
                        {
                            VIN = "1HGCM82633A123456",
                            BodyDoorCount = 4,
                            CityMPG = 25,
                            DrivetrainId = 1,
                            Engine = "V6",
                            EngineCylinderCount = 6,
                            EngineDisplacement = "3.5L",
                            ExteriorColourId = 1,
                            Fuel = "Gasoline",
                            Height = 57.1m,
                            HighwayMPG = 35,
                            InteriorColourId = 2,
                            Length = 190.9m,
                            ManufacturerId = 1,
                            ModelId = 1,
                            SeriesId = 1,
                            TransmissionId = 1,
                            VehicleTypeId = 1,
                            Weight = 1500m,
                            Width = 73.9m,
                            Year = 2020
                        });
                });

            modelBuilder.Entity("MACK.Models.VehicleListing", b =>
                {
                    b.Property<int>("ListingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<bool>("Certified")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("ConditionId")
                        .HasColumnType("int");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("DealershipId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Features")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("InventoryDate")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("MSRP")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Odometer")
                        .HasColumnType("int");

                    b.Property<string>("PhotoUrlList")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("PhotosLastModifiedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("StockNumber")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("VIN")
                        .IsRequired()
                        .HasColumnType("varchar(17)");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("deleted_at")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ListingId");

                    b.HasIndex("ConditionId");

                    b.HasIndex("DealershipId");

                    b.HasIndex("VIN");

                    b.HasIndex("StockNumber", "DealershipId")
                        .IsUnique();

                    b.ToTable("VehicleListings");

                    b.HasData(
                        new
                        {
                            ListingId = 1,
                            Age = 3,
                            Certified = true,
                            ConditionId = 1,
                            Cost = 20000m,
                            DealershipId = 1,
                            Description = "Excellent condition, low mileage",
                            Features = "Leather seats, sunroof, navigation system",
                            InventoryDate = new DateTime(2023, 5, 15, 14, 49, 43, 349, DateTimeKind.Local).AddTicks(4150),
                            MSRP = 25000m,
                            Odometer = 5000,
                            PhotoUrlList = "www.example.com/photo1.jpg,www.example.com/photo2.jpg",
                            PhotosLastModifiedDate = new DateTime(2023, 5, 15, 14, 49, 43, 349, DateTimeKind.Local).AddTicks(4180),
                            Price = 24000m,
                            StockNumber = "AG123",
                            VIN = "1HGCM82633A123456",
                            created_at = new DateTime(2023, 5, 15, 14, 49, 43, 349, DateTimeKind.Local).AddTicks(4180),
                            deleted_at = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            updated_at = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("MACK.Models.VehicleType", b =>
                {
                    b.Property<int>("VehicleTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("VehicleTypeId");

                    b.HasIndex("TypeName")
                        .IsUnique();

                    b.ToTable("VehicleTypes");

                    b.HasData(
                        new
                        {
                            VehicleTypeId = 1,
                            TypeName = "Sedan"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("MACK.Models.Corporation", b =>
                {
                    b.HasOne("MACK.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("MACK.Models.Dealership", b =>
                {
                    b.HasOne("MACK.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MACK.Models.Address", null)
                        .WithMany("Dealerships")
                        .HasForeignKey("AddressId1");

                    b.HasOne("MACK.Models.Corporation", "Corporation")
                        .WithMany()
                        .HasForeignKey("CorporationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MACK.Models.Corporation", null)
                        .WithMany("Dealerships")
                        .HasForeignKey("CorporationId1");

                    b.Navigation("Address");

                    b.Navigation("Corporation");
                });

            modelBuilder.Entity("MACK.Models.Model", b =>
                {
                    b.HasOne("MACK.Models.Manufacturer", "Manufacturer")
                        .WithMany("Models")
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manufacturer");
                });

            modelBuilder.Entity("MACK.Models.Series", b =>
                {
                    b.HasOne("MACK.Models.Model", "Model")
                        .WithMany("Series")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Model");
                });

            modelBuilder.Entity("MACK.Models.Vehicle", b =>
                {
                    b.HasOne("MACK.Models.Drivetrain", "Drivetrain")
                        .WithMany("Vehicles")
                        .HasForeignKey("DrivetrainId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MACK.Models.Colour", "ExteriorColour")
                        .WithMany("VehiclesExterior")
                        .HasForeignKey("ExteriorColourId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MACK.Models.Colour", "InteriorColour")
                        .WithMany("VehiclesInterior")
                        .HasForeignKey("InteriorColourId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MACK.Models.Manufacturer", "Manufacturer")
                        .WithMany("Vehicles")
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MACK.Models.Model", "Model")
                        .WithMany("Vehicles")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MACK.Models.Series", "Series")
                        .WithMany("Vehicles")
                        .HasForeignKey("SeriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MACK.Models.Transmission", "Transmission")
                        .WithMany("Vehicles")
                        .HasForeignKey("TransmissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MACK.Models.VehicleType", "VehicleType")
                        .WithMany("Vehicles")
                        .HasForeignKey("VehicleTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Drivetrain");

                    b.Navigation("ExteriorColour");

                    b.Navigation("InteriorColour");

                    b.Navigation("Manufacturer");

                    b.Navigation("Model");

                    b.Navigation("Series");

                    b.Navigation("Transmission");

                    b.Navigation("VehicleType");
                });

            modelBuilder.Entity("MACK.Models.VehicleListing", b =>
                {
                    b.HasOne("MACK.Models.Condition", "Condition")
                        .WithMany("VehicleListings")
                        .HasForeignKey("ConditionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MACK.Models.Dealership", "Dealership")
                        .WithMany("VehicleListings")
                        .HasForeignKey("DealershipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MACK.Models.Vehicle", "Vehicle")
                        .WithMany("VehicleListings")
                        .HasForeignKey("VIN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Condition");

                    b.Navigation("Dealership");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MACK.Models.Address", b =>
                {
                    b.Navigation("Dealerships");
                });

            modelBuilder.Entity("MACK.Models.Colour", b =>
                {
                    b.Navigation("VehiclesExterior");

                    b.Navigation("VehiclesInterior");
                });

            modelBuilder.Entity("MACK.Models.Condition", b =>
                {
                    b.Navigation("VehicleListings");
                });

            modelBuilder.Entity("MACK.Models.Corporation", b =>
                {
                    b.Navigation("Dealerships");
                });

            modelBuilder.Entity("MACK.Models.Dealership", b =>
                {
                    b.Navigation("VehicleListings");
                });

            modelBuilder.Entity("MACK.Models.Drivetrain", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("MACK.Models.Manufacturer", b =>
                {
                    b.Navigation("Models");

                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("MACK.Models.Model", b =>
                {
                    b.Navigation("Series");

                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("MACK.Models.Series", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("MACK.Models.Transmission", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("MACK.Models.Vehicle", b =>
                {
                    b.Navigation("VehicleListings");
                });

            modelBuilder.Entity("MACK.Models.VehicleType", b =>
                {
                    b.Navigation("Vehicles");
                });
#pragma warning restore 612, 618
        }
    }
}
