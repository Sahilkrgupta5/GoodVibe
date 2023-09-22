using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoodVibe.Migrations
{
    /// <inheritdoc />
    public partial class AddressColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Properties",
                newName: "State");

            migrationBuilder.AddColumn<string>(
                name: "Area",
                table: "Properties",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Properties",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HouseNo",
                table: "Properties",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PinCode",
                table: "Properties",
                type: "int",
                maxLength: 100,
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Area",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "HouseNo",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "PinCode",
                table: "Properties");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Properties",
                newName: "Address");
        }
    }
}
