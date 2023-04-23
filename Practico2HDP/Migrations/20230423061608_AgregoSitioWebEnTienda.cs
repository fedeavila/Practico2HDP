using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Practico2HDP.Migrations
{
    /// <inheritdoc />
    public partial class AgregoSitioWebEnTienda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Web",
                table: "Tienda",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Web",
                table: "Tienda");
        }
    }
}
