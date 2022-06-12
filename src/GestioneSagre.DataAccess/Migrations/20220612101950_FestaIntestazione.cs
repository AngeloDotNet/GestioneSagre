using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestioneSagre.DataAccess.Migrations
{
    public partial class FestaIntestazione : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TestoVersione",
                table: "Versione",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CodiceVersione",
                table: "Versione",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Festa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataInizio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataFine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuidFesta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusFesta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Festa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Intestazione",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FestaId = table.Column<int>(type: "int", nullable: false),
                    Titolo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Edizione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Luogo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intestazione", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Intestazione_Festa_FestaId",
                        column: x => x.FestaId,
                        principalTable: "Festa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Intestazione_FestaId",
                table: "Intestazione",
                column: "FestaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Intestazione");

            migrationBuilder.DropTable(
                name: "Festa");

            migrationBuilder.AlterColumn<string>(
                name: "TestoVersione",
                table: "Versione",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CodiceVersione",
                table: "Versione",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
