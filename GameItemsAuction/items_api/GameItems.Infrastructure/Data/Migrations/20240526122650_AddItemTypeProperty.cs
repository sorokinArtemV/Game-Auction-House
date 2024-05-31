using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameItems.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddItemTypeProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ItemType",
                table: "Weapons",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ItemType",
                table: "Armors",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemType",
                table: "Weapons");

            migrationBuilder.DropColumn(
                name: "ItemType",
                table: "Armors");
        }
    }
}
