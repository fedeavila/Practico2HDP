using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Practico2HDP.Migrations
{
    /// <inheritdoc />
    public partial class AgregoModelClientes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TiendaID",
                table: "Bicicleta",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Apellido = table.Column<string>(type: "TEXT", nullable: false),
                    DNI = table.Column<string>(type: "TEXT", nullable: false),
                    ConsumidorFinal = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bicicleta_TiendaID",
                table: "Bicicleta",
                column: "TiendaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bicicleta_Tienda_TiendaID",
                table: "Bicicleta",
                column: "TiendaID",
                principalTable: "Tienda",
                principalColumn: "TiendaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bicicleta_Tienda_TiendaID",
                table: "Bicicleta");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropIndex(
                name: "IX_Bicicleta_TiendaID",
                table: "Bicicleta");

            migrationBuilder.DropColumn(
                name: "TiendaID",
                table: "Bicicleta");
        }
    }
}
