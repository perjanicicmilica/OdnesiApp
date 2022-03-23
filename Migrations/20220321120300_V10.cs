using Microsoft.EntityFrameworkCore.Migrations;

namespace Odnesi.Migrations
{
    public partial class V10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdavnicaKategorija");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProdavnicaKategorija",
                columns: table => new
                {
                    IdSpoja = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategorijaIdKategorije = table.Column<int>(type: "int", nullable: true),
                    ProdavnicaIdProdavnice = table.Column<int>(type: "int", nullable: true),
                    ProizvodIdProizvoda = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdavnicaKategorija", x => x.IdSpoja);
                    table.ForeignKey(
                        name: "FK_ProdavnicaKategorija_Kategorije_KategorijaIdKategorije",
                        column: x => x.KategorijaIdKategorije,
                        principalTable: "Kategorije",
                        principalColumn: "IdKategorije",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProdavnicaKategorija_Prodavnica_ProdavnicaIdProdavnice",
                        column: x => x.ProdavnicaIdProdavnice,
                        principalTable: "Prodavnica",
                        principalColumn: "IdProdavnice",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProdavnicaKategorija_Proizvodi_ProizvodIdProizvoda",
                        column: x => x.ProizvodIdProizvoda,
                        principalTable: "Proizvodi",
                        principalColumn: "IdProizvoda",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProdavnicaKategorija_KategorijaIdKategorije",
                table: "ProdavnicaKategorija",
                column: "KategorijaIdKategorije");

            migrationBuilder.CreateIndex(
                name: "IX_ProdavnicaKategorija_ProdavnicaIdProdavnice",
                table: "ProdavnicaKategorija",
                column: "ProdavnicaIdProdavnice");

            migrationBuilder.CreateIndex(
                name: "IX_ProdavnicaKategorija_ProizvodIdProizvoda",
                table: "ProdavnicaKategorija",
                column: "ProizvodIdProizvoda");
        }
    }
}
