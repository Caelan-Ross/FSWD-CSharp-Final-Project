using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MACK.Migrations
{
    /// <inheritdoc />
    public partial class DBUpdate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dimensions",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "weight",
                table: "Vehicles");

            migrationBuilder.AddColumn<double>(
                name: "price",
                table: "Vehicles",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "stock_number",
                table: "Vehicles",
                type: "varchar(24)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "vehicle_id",
                keyValue: -1,
                columns: new[] { "price", "stock_number" },
                values: new object[] { 0.10000000000000001, "A1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "price",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "stock_number",
                table: "Vehicles");

            migrationBuilder.AddColumn<string>(
                name: "dimensions",
                table: "Vehicles",
                type: "varchar(128)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "weight",
                table: "Vehicles",
                type: "int(5)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "vehicle_id",
                keyValue: -1,
                columns: new[] { "dimensions", "weight" },
                values: new object[] { "1x1x1", 4000 });
        }
    }
}
