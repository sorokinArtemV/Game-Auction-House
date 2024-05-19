using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItemsService.ItemsServiceInfrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsShield",
                table: "Armors");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsShield",
                table: "Armors",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
