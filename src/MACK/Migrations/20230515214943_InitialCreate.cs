using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MACK.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Street = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    City = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Province = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PostalCode = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Country = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Colours",
                columns: table => new
                {
                    ColourId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ColourName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colours", x => x.ColourId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Conditions",
                columns: table => new
                {
                    ConditionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ConditionName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conditions", x => x.ConditionId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Drivetrains",
                columns: table => new
                {
                    DrivetrainId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DrivetrainType = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivetrains", x => x.DrivetrainId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    ManufacturerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ManufacturerName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.ManufacturerId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Transmissions",
                columns: table => new
                {
                    TransmissionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TransmissionType = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TransmissionGears = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transmissions", x => x.TransmissionId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "VehicleTypes",
                columns: table => new
                {
                    VehicleTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TypeName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleTypes", x => x.VehicleTypeId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Corporations",
                columns: table => new
                {
                    CorporationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CorporationName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corporations", x => x.CorporationId);
                    table.ForeignKey(
                        name: "FK_Corporations_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderKey = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LoginProvider = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    ModelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ModelName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ManufacturerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.ModelId);
                    table.ForeignKey(
                        name: "FK_Models_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "ManufacturerId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Dealerships",
                columns: table => new
                {
                    DealershipId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CorporationId = table.Column<int>(type: "int", nullable: false),
                    DealershipName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    AddressId1 = table.Column<int>(type: "int", nullable: true),
                    CorporationId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dealerships", x => x.DealershipId);
                    table.ForeignKey(
                        name: "FK_Dealerships_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dealerships_Addresses_AddressId1",
                        column: x => x.AddressId1,
                        principalTable: "Addresses",
                        principalColumn: "AddressId");
                    table.ForeignKey(
                        name: "FK_Dealerships_Corporations_CorporationId",
                        column: x => x.CorporationId,
                        principalTable: "Corporations",
                        principalColumn: "CorporationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dealerships_Corporations_CorporationId1",
                        column: x => x.CorporationId1,
                        principalTable: "Corporations",
                        principalColumn: "CorporationId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    SeriesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SeriesName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.SeriesId);
                    table.ForeignKey(
                        name: "FK_Series_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "ModelId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    VIN = table.Column<string>(type: "varchar(17)", maxLength: 17, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Year = table.Column<int>(type: "int", nullable: false),
                    ManufacturerId = table.Column<int>(type: "int", nullable: false),
                    ModelId = table.Column<int>(type: "int", nullable: false),
                    SeriesId = table.Column<int>(type: "int", nullable: false),
                    VehicleTypeId = table.Column<int>(type: "int", nullable: false),
                    EngineCylinderCount = table.Column<int>(type: "int", nullable: false),
                    EngineDisplacement = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Engine = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Fuel = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TransmissionId = table.Column<int>(type: "int", nullable: false),
                    BodyDoorCount = table.Column<int>(type: "int", nullable: false),
                    DrivetrainId = table.Column<int>(type: "int", nullable: false),
                    ExteriorColourId = table.Column<int>(type: "int", nullable: false),
                    InteriorColourId = table.Column<int>(type: "int", nullable: false),
                    CityMPG = table.Column<int>(type: "int", nullable: false),
                    HighwayMPG = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Length = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Width = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Height = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.VIN);
                    table.ForeignKey(
                        name: "FK_Vehicles_Colours_ExteriorColourId",
                        column: x => x.ExteriorColourId,
                        principalTable: "Colours",
                        principalColumn: "ColourId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_Colours_InteriorColourId",
                        column: x => x.InteriorColourId,
                        principalTable: "Colours",
                        principalColumn: "ColourId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_Drivetrains_DrivetrainId",
                        column: x => x.DrivetrainId,
                        principalTable: "Drivetrains",
                        principalColumn: "DrivetrainId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "ManufacturerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "ModelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Series",
                        principalColumn: "SeriesId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_Transmissions_TransmissionId",
                        column: x => x.TransmissionId,
                        principalTable: "Transmissions",
                        principalColumn: "TransmissionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleTypes_VehicleTypeId",
                        column: x => x.VehicleTypeId,
                        principalTable: "VehicleTypes",
                        principalColumn: "VehicleTypeId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "VehicleListings",
                columns: table => new
                {
                    ListingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    VIN = table.Column<string>(type: "varchar(17)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StockNumber = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConditionId = table.Column<int>(type: "int", nullable: false),
                    Odometer = table.Column<int>(type: "int", nullable: false),
                    MSRP = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InventoryDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Certified = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Features = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhotoUrlList = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhotosLastModifiedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DealershipId = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleListings", x => x.ListingId);
                    table.ForeignKey(
                        name: "FK_VehicleListings_Conditions_ConditionId",
                        column: x => x.ConditionId,
                        principalTable: "Conditions",
                        principalColumn: "ConditionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleListings_Dealerships_DealershipId",
                        column: x => x.DealershipId,
                        principalTable: "Dealerships",
                        principalColumn: "DealershipId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleListings_Vehicles_VIN",
                        column: x => x.VIN,
                        principalTable: "Vehicles",
                        principalColumn: "VIN",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "AddressId", "City", "Country", "PostalCode", "Province", "Street" },
                values: new object[,]
                {
                    { 1, "Prince Albert", "CA", "S6V-2X1", "Saskatchewan", "123 Main Street" },
                    { 2, "Prince Albert", "CA", "S6V-3Y2", "Saskatchewan", "456 Secondary Road" }
                });

            migrationBuilder.InsertData(
                table: "Colours",
                columns: new[] { "ColourId", "ColourName" },
                values: new object[,]
                {
                    { 1, "Red" },
                    { 2, "Black" }
                });

            migrationBuilder.InsertData(
                table: "Conditions",
                columns: new[] { "ConditionId", "ConditionName" },
                values: new object[] { 1, "Used" });

            migrationBuilder.InsertData(
                table: "Drivetrains",
                columns: new[] { "DrivetrainId", "DrivetrainType" },
                values: new object[] { 1, "FWD" });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "ManufacturerId", "ManufacturerName" },
                values: new object[] { 1, "Honda" });

            migrationBuilder.InsertData(
                table: "Transmissions",
                columns: new[] { "TransmissionId", "TransmissionGears", "TransmissionType" },
                values: new object[] { 1, 6, "Automatic" });

            migrationBuilder.InsertData(
                table: "VehicleTypes",
                columns: new[] { "VehicleTypeId", "TypeName" },
                values: new object[] { 1, "Sedan" });

            migrationBuilder.InsertData(
                table: "Corporations",
                columns: new[] { "CorporationId", "AddressId", "CorporationName" },
                values: new object[] { 1, 1, "AutoGroup Inc." });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "ModelId", "ManufacturerId", "ModelName" },
                values: new object[] { 1, 1, "Accord" });

            migrationBuilder.InsertData(
                table: "Dealerships",
                columns: new[] { "DealershipId", "AddressId", "AddressId1", "CorporationId", "CorporationId1", "DealershipName" },
                values: new object[] { 1, 2, null, 1, null, "Lakeland Ford" });

            migrationBuilder.InsertData(
                table: "Series",
                columns: new[] { "SeriesId", "ModelId", "SeriesName" },
                values: new object[] { 1, 1, "LX" });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "VIN", "BodyDoorCount", "CityMPG", "DrivetrainId", "Engine", "EngineCylinderCount", "EngineDisplacement", "ExteriorColourId", "Fuel", "Height", "HighwayMPG", "InteriorColourId", "Length", "ManufacturerId", "ModelId", "SeriesId", "TransmissionId", "VehicleTypeId", "Weight", "Width", "Year" },
                values: new object[] { "1HGCM82633A123456", 4, 25, 1, "V6", 6, "3.5L", 1, "Gasoline", 57.1m, 35, 2, 190.9m, 1, 1, 1, 1, 1, 1500m, 73.9m, 2020 });

            migrationBuilder.InsertData(
                table: "VehicleListings",
                columns: new[] { "ListingId", "Age", "Certified", "ConditionId", "Cost", "DealershipId", "Description", "Features", "InventoryDate", "MSRP", "Odometer", "PhotoUrlList", "PhotosLastModifiedDate", "Price", "StockNumber", "VIN", "created_at", "deleted_at", "updated_at" },
                values: new object[] { 1, 3, true, 1, 20000m, 1, "Excellent condition, low mileage", "Leather seats, sunroof, navigation system", new DateTime(2023, 5, 15, 14, 49, 43, 349, DateTimeKind.Local).AddTicks(4150), 25000m, 5000, "www.example.com/photo1.jpg,www.example.com/photo2.jpg", new DateTime(2023, 5, 15, 14, 49, 43, 349, DateTimeKind.Local).AddTicks(4180), 24000m, "AG123", "1HGCM82633A123456", new DateTime(2023, 5, 15, 14, 49, 43, 349, DateTimeKind.Local).AddTicks(4180), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Colours_ColourName",
                table: "Colours",
                column: "ColourName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Conditions_ConditionName",
                table: "Conditions",
                column: "ConditionName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Corporations_AddressId",
                table: "Corporations",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Corporations_CorporationName",
                table: "Corporations",
                column: "CorporationName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dealerships_AddressId",
                table: "Dealerships",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Dealerships_AddressId1",
                table: "Dealerships",
                column: "AddressId1");

            migrationBuilder.CreateIndex(
                name: "IX_Dealerships_CorporationId",
                table: "Dealerships",
                column: "CorporationId");

            migrationBuilder.CreateIndex(
                name: "IX_Dealerships_CorporationId1",
                table: "Dealerships",
                column: "CorporationId1");

            migrationBuilder.CreateIndex(
                name: "IX_Drivetrains_DrivetrainType",
                table: "Drivetrains",
                column: "DrivetrainType",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturers_ManufacturerName",
                table: "Manufacturers",
                column: "ManufacturerName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Models_ManufacturerId",
                table: "Models",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Models_ModelName_ManufacturerId",
                table: "Models",
                columns: new[] { "ModelName", "ManufacturerId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Series_ModelId",
                table: "Series",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Series_SeriesName_ModelId",
                table: "Series",
                columns: new[] { "SeriesName", "ModelId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transmissions_TransmissionType",
                table: "Transmissions",
                column: "TransmissionType",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleListings_ConditionId",
                table: "VehicleListings",
                column: "ConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleListings_DealershipId",
                table: "VehicleListings",
                column: "DealershipId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleListings_StockNumber_DealershipId",
                table: "VehicleListings",
                columns: new[] { "StockNumber", "DealershipId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleListings_VIN",
                table: "VehicleListings",
                column: "VIN");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_DrivetrainId",
                table: "Vehicles",
                column: "DrivetrainId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ExteriorColourId",
                table: "Vehicles",
                column: "ExteriorColourId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_InteriorColourId",
                table: "Vehicles",
                column: "InteriorColourId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ManufacturerId",
                table: "Vehicles",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ModelId",
                table: "Vehicles",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_SeriesId",
                table: "Vehicles",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_TransmissionId",
                table: "Vehicles",
                column: "TransmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleTypeId",
                table: "Vehicles",
                column: "VehicleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VIN",
                table: "Vehicles",
                column: "VIN",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleTypes_TypeName",
                table: "VehicleTypes",
                column: "TypeName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "VehicleListings");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Conditions");

            migrationBuilder.DropTable(
                name: "Dealerships");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Corporations");

            migrationBuilder.DropTable(
                name: "Colours");

            migrationBuilder.DropTable(
                name: "Drivetrains");

            migrationBuilder.DropTable(
                name: "Series");

            migrationBuilder.DropTable(
                name: "Transmissions");

            migrationBuilder.DropTable(
                name: "VehicleTypes");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "Manufacturers");
        }
    }
}
