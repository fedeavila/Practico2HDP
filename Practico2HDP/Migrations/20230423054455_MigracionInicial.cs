using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Practico2HDP.Migrations
{
    /// <inheritdoc />
    public partial class MigracionInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bicicleta",
                columns: table => new
                {
                    BicicletaID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Marca = table.Column<string>(type: "TEXT", nullable: false),
                    Modelo = table.Column<string>(type: "TEXT", nullable: false),
                    Categoria = table.Column<string>(type: "TEXT", nullable: false),
                    EsElectrica = table.Column<bool>(type: "INTEGER", nullable: false),
                    Color = table.Column<string>(type: "TEXT", nullable: false),
                    Anio = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bicicleta", x => x.BicicletaID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bicicleta");
        }
    }
}
