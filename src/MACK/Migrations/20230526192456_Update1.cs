using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MACK.Migrations
{
    /// <inheritdoc />
    public partial class Update1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Corporations_corporation_id",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Dealerships_dealership_id",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Manufacturers_manufacturer_id",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Models_model_id",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_manufacturer_id",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_model_id",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_corporation_id",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "manufacturer_id",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "model_id",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "address_id",
                table: "Corporations");

            migrationBuilder.DropColumn(
                name: "vehicle_listing_id",
                table: "Conditions");

            migrationBuilder.DropColumn(
                name: "corporation_id",
                table: "Addresses");

            migrationBuilder.AlterColumn<int>(
                name: "dealership_id",
                table: "Addresses",
                type: "int(10)",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int(10)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Colours",
                columns: new[] { "colour_id", "colour_name", "vehicle_id" },
                values: new object[] { -1, "Blue", -1 });

            migrationBuilder.InsertData(
                table: "Conditions",
                columns: new[] { "condition_id", "condition_name" },
                values: new object[] { -1, "Used" });

            migrationBuilder.InsertData(
                table: "Corporations",
                columns: new[] { "corporation_id", "corporation_name" },
                values: new object[] { -1, "TestCorporation" });

            migrationBuilder.InsertData(
                table: "Drivetrains",
                columns: new[] { "drivetrain_id", "drivetrain_type", "vehicle_id" },
                values: new object[] { -1, "TestDrivetrain", -1 });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "manufacturer_id", "manufacturer_name" },
                values: new object[] { -1, "TestManufacturer" });

            migrationBuilder.InsertData(
                table: "Transmissions",
                columns: new[] { "transmission_id", "transmission_gears", "transmission_type" },
                values: new object[] { -1, 1, "TestType" });

            migrationBuilder.InsertData(
                table: "VehicleTypes",
                columns: new[] { "vehicle_type_id", "type_name" },
                values: new object[] { -1, "TestType" });

            migrationBuilder.InsertData(
                table: "Dealerships",
                columns: new[] { "dealership_id", "address_id", "corperation_id", "dealership_name" },
                values: new object[] { -1, -1, -1, "TestDealership" });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "model_id", "manufacturer_id", "model_name" },
                values: new object[] { -1, -1, "TestModel" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "address_id", "city", "country", "dealership_id", "postal_code", "province", "street" },
                values: new object[] { -1, "Edmonton", "Canada", -1, "A1A1A1", "Alberta", "123 Street" });

            migrationBuilder.InsertData(
                table: "Series",
                columns: new[] { "series_id", "model_id", "series_name" },
                values: new object[] { -1, -1, "TestSeries" });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "vehicle_id", "body_door_count", "city_mpg", "drivetrain_id", "engine", "engine_cylinder_count", "engine_displacement", "ExteriorColourId", "fuel", "height", "highway_mpg", "InteriorColourId", "length", "series_id", "transmission_id", "vin", "vehicle_type_id", "weight", "width", "model_year" },
                values: new object[] { -1, 1, 1, -1, "TestEngine", 1, "TestDisplacment", -1, "TestFuel", 1m, 1, -1, 1m, -1, -1, "11111111111111111", -1, 1m, 1m, 2000 });

            migrationBuilder.InsertData(
                table: "VehicleListings",
                columns: new[] { "listing_id", "age", "certified", "condition_id", "cost", "created_at", "dealership_id", "deleted_at", "description", "features", "inventory_date", "msrp", "odometer", "photo_url_list", "photos_last_modified_date", "price", "stock_number", "updated_at", "vin", "vehicle_id" },
                values: new object[] { -1, 1, true, -1, 1m, new DateTime(2023, 5, 26, 14, 24, 56, 185, DateTimeKind.Local).AddTicks(6746), -1, new DateTime(2023, 5, 26, 14, 24, 56, 185, DateTimeKind.Local).AddTicks(6749), "TestDescription", "TestFeatures", new DateTime(2023, 5, 26, 14, 24, 56, 185, DateTimeKind.Local).AddTicks(6707), 1, 1, "TestPhotoList", new DateTime(2023, 5, 26, 14, 24, 56, 185, DateTimeKind.Local).AddTicks(6744), 1, "Test", new DateTime(2023, 5, 26, 14, 24, 56, 185, DateTimeKind.Local).AddTicks(6747), "11111111111111111", -1 });

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Dealerships_dealership_id",
                table: "Addresses",
                column: "dealership_id",
                principalTable: "Dealerships",
                principalColumn: "dealership_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Dealerships_dealership_id",
                table: "Addresses");

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "address_id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "VehicleListings",
                keyColumn: "listing_id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "Conditions",
                keyColumn: "condition_id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "Dealerships",
                keyColumn: "dealership_id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "vehicle_id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "Colours",
                keyColumn: "colour_id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "Corporations",
                keyColumn: "corporation_id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "Drivetrains",
                keyColumn: "drivetrain_id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "Series",
                keyColumn: "series_id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "Transmissions",
                keyColumn: "transmission_id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "VehicleTypes",
                keyColumn: "vehicle_type_id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "model_id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "manufacturer_id",
                keyValue: -1);

            migrationBuilder.AddColumn<int>(
                name: "manufacturer_id",
                table: "Vehicles",
                type: "int(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "model_id",
                table: "Vehicles",
                type: "int(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "address_id",
                table: "Corporations",
                type: "int(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "vehicle_listing_id",
                table: "Conditions",
                type: "int(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "dealership_id",
                table: "Addresses",
                type: "int(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int(10)");

            migrationBuilder.AddColumn<int>(
                name: "corporation_id",
                table: "Addresses",
                type: "int(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_manufacturer_id",
                table: "Vehicles",
                column: "manufacturer_id");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_model_id",
                table: "Vehicles",
                column: "model_id");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_corporation_id",
                table: "Addresses",
                column: "corporation_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Corporations_corporation_id",
                table: "Addresses",
                column: "corporation_id",
                principalTable: "Corporations",
                principalColumn: "corporation_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Dealerships_dealership_id",
                table: "Addresses",
                column: "dealership_id",
                principalTable: "Dealerships",
                principalColumn: "dealership_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Manufacturers_manufacturer_id",
                table: "Vehicles",
                column: "manufacturer_id",
                principalTable: "Manufacturers",
                principalColumn: "manufacturer_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Models_model_id",
                table: "Vehicles",
                column: "model_id",
                principalTable: "Models",
                principalColumn: "model_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
