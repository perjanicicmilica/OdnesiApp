using Microsoft.EntityFrameworkCore.Migrations;

namespace Odnesi.Migrations
{
    public partial class V12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proizvodi_Kategorije_KategorijaIdKategorije",
                table: "Proizvodi");

            migrationBuilder.DropIndex(
                name: "IX_Proizvodi_KategorijaIdKategorije",
                table: "Proizvodi");

            migrationBuilder.DropColumn(
                name: "KategorijaIdKategorije",
                table: "Proizvodi");

            migrationBuilder.CreateTable(
                name: "KategorijaProizvodi",
                columns: table => new
                {
                    ProizvodiKategorijamaIdKategorije = table.Column<int>(type: "int", nullable: false),
                    ProizvodiKategorijeIdProizvoda = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KategorijaProizvodi", x => new { x.ProizvodiKategorijamaIdKategorije, x.ProizvodiKategorijeIdProizvoda });
                    table.ForeignKey(
                        name: "FK_KategorijaProizvodi_Kategorije_ProizvodiKategorijamaIdKategorije",
                        column: x => x.ProizvodiKategorijamaIdKategorije,
                        principalTable: "Kategorije",
                        principalColumn: "IdKategorije",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KategorijaProizvodi_Proizvodi_ProizvodiKategorijeIdProizvoda",
                        column: x => x.ProizvodiKategorijeIdProizvoda,
                        principalTable: "Proizvodi",
                        principalColumn: "IdProizvoda",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KategorijaProizvodi_ProizvodiKategorijeIdProizvoda",
                table: "KategorijaProizvodi",
                column: "ProizvodiKategorijeIdProizvoda");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KategorijaProizvodi");

            migrationBuilder.AddColumn<int>(
                name: "KategorijaIdKategorije",
                table: "Proizvodi",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Proizvodi_KategorijaIdKategorije",
                table: "Proizvodi",
                column: "KategorijaIdKategorije");

            migrationBuilder.AddForeignKey(
                name: "FK_Proizvodi_Kategorije_KategorijaIdKategorije",
                table: "Proizvodi",
                column: "KategorijaIdKategorije",
                principalTable: "Kategorije",
                principalColumn: "IdKategorije",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
