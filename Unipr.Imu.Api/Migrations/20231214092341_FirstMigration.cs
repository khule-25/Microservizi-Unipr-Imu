using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Imu.Api.Migrations;

/// <inheritdoc />
public partial class FirstMigration : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "CategorieCatastali",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Codice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_CategorieCatastali", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Immobili",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                IdCategoriaCatastale = table.Column<int>(type: "int", nullable: false),
                Superficie = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                Rendita = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                Sezione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Foglio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Particella = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Subalterno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Indirizzo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                NumeroCivico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Cap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Provincia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Localita = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Immobili", x => x.Id);
                table.ForeignKey(
                    name: "FK_Immobili_CategorieCatastali_IdCategoriaCatastale",
                    column: x => x.IdCategoriaCatastale,
                    principalTable: "CategorieCatastali",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "AnagraficheImmobili",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                IdAnagrafica = table.Column<int>(type: "int", nullable: false),
                IdImmobile = table.Column<int>(type: "int", nullable: false),
                Quota = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AnagraficheImmobili", x => x.Id);
                table.ForeignKey(
                    name: "FK_AnagraficheImmobili_Immobili_IdImmobile",
                    column: x => x.IdImmobile,
                    principalTable: "Immobili",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_AnagraficheImmobili_IdImmobile",
            table: "AnagraficheImmobili",
            column: "IdImmobile");

        migrationBuilder.CreateIndex(
            name: "IX_Immobili_IdCategoriaCatastale",
            table: "Immobili",
            column: "IdCategoriaCatastale");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "AnagraficheImmobili");

        migrationBuilder.DropTable(
            name: "Immobili");

        migrationBuilder.DropTable(
            name: "CategorieCatastali");
    }
}
