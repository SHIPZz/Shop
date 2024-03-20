using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "Devices");

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "OrderedDevices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "OrderedDevices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsPurchased",
                table: "OrderedDevices",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "OrderedDevices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "OrderedDevices",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "OrderedDevices");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "OrderedDevices");

            migrationBuilder.DropColumn(
                name: "IsPurchased",
                table: "OrderedDevices");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "OrderedDevices");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "OrderedDevices");

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "Devices",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
