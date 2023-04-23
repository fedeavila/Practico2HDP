using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Practico2HDP.Migrations
{
    /// <inheritdoc />
    public partial class AgregoTiendas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tienda",
                columns: table => new
                {
                    TiendaID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RazonSocial = table.Column<string>(type: "TEXT", nullable: false),
                    Direccion = table.Column<string>(type: "TEXT", nullable: false),
                    Tel = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tienda", x => x.TiendaID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tienda");
        }
    }
}
