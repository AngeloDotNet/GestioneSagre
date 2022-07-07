using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestioneSagre.DataAccess.Migrations
{
    public partial class MappingOwnedTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriaVideo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoriaStampa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prodotto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    Prodotto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProdottoAttivo = table.Column<bool>(type: "bit", nullable: false),
                    Prezzo_Amount = table.Column<float>(type: "real", nullable: true),
                    Prezzo_Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantita = table.Column<int>(type: "int", nullable: false),
                    QuantitaAttiva = table.Column<bool>(type: "bit", nullable: false),
                    QuantitaScorta = table.Column<int>(type: "int", nullable: false),
                    AvvisoScorta = table.Column<bool>(type: "bit", nullable: false),
                    Prenotazione = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prodotto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prodotto_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prodotto_CategoriaId",
                table: "Prodotto",
                column: "CategoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prodotto");

            migrationBuilder.DropTable(
                name: "Categoria");
        }
    }
}
