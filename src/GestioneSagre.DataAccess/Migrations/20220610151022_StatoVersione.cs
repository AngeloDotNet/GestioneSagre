using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestioneSagre.DataAccess.Migrations
{
    public partial class StatoVersione : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VersioneStato",
                table: "Versione",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VersioneStato",
                table: "Versione");
        }
    }
}
