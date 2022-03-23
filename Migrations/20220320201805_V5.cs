using Microsoft.EntityFrameworkCore.Migrations;

namespace Odnesi.Migrations
{
    public partial class V5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategorije",
                columns: table => new
                {
                    IdKategorije = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorije", x => x.IdKategorije);
                });

            migrationBuilder.CreateTable(
                name: "Narudzbenica",
                columns: table => new
                {
                    IdNarudzbenice = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImeiPrezime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AdresaKupca = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Racun = table.Column<int>(type: "int", nullable: false),
                    DatumNarudzbenice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Narudzbenica", x => x.IdNarudzbenice);
                });

            migrationBuilder.CreateTable(
                name: "Prodavnica",
                columns: table => new
                {
                    IdProdavnice = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prodavnica", x => x.IdProdavnice);
                });

            migrationBuilder.CreateTable(
                name: "Proizvodi",
                columns: table => new
                {
                    IdProizvoda = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Cena = table.Column<int>(type: "int", nullable: false),
                    Popust = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proizvodi", x => x.IdProizvoda);
                });

            migrationBuilder.CreateTable(
                name: "ProdavnicaKategorija",
                columns: table => new
                {
                    IdSpoja = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdavnicaIdProdavnice = table.Column<int>(type: "int", nullable: true),
                    KategorijaIdKategorije = table.Column<int>(type: "int", nullable: true),
                    NarudzbenicaIdNarudzbenice = table.Column<int>(type: "int", nullable: true)
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
                        name: "FK_ProdavnicaKategorija_Narudzbenica_NarudzbenicaIdNarudzbenice",
                        column: x => x.NarudzbenicaIdNarudzbenice,
                        principalTable: "Narudzbenica",
                        principalColumn: "IdNarudzbenice",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProdavnicaKategorija_Prodavnica_ProdavnicaIdProdavnice",
                        column: x => x.ProdavnicaIdProdavnice,
                        principalTable: "Prodavnica",
                        principalColumn: "IdProdavnice",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProizvodiKategorija",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ocena = table.Column<int>(type: "int", nullable: false),
                    KategorijaIdKategorije = table.Column<int>(type: "int", nullable: true),
                    NarudzbenicaIdNarudzbenice = table.Column<int>(type: "int", nullable: true),
                    ProizvodiIdProizvoda = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProizvodiKategorija", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProizvodiKategorija_Kategorije_KategorijaIdKategorije",
                        column: x => x.KategorijaIdKategorije,
                        principalTable: "Kategorije",
                        principalColumn: "IdKategorije",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProizvodiKategorija_Narudzbenica_NarudzbenicaIdNarudzbenice",
                        column: x => x.NarudzbenicaIdNarudzbenice,
                        principalTable: "Narudzbenica",
                        principalColumn: "IdNarudzbenice",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProizvodiKategorija_Proizvodi_ProizvodiIdProizvoda",
                        column: x => x.ProizvodiIdProizvoda,
                        principalTable: "Proizvodi",
                        principalColumn: "IdProizvoda",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProdavnicaKategorija_KategorijaIdKategorije",
                table: "ProdavnicaKategorija",
                column: "KategorijaIdKategorije");

            migrationBuilder.CreateIndex(
                name: "IX_ProdavnicaKategorija_NarudzbenicaIdNarudzbenice",
                table: "ProdavnicaKategorija",
                column: "NarudzbenicaIdNarudzbenice");

            migrationBuilder.CreateIndex(
                name: "IX_ProdavnicaKategorija_ProdavnicaIdProdavnice",
                table: "ProdavnicaKategorija",
                column: "ProdavnicaIdProdavnice");

            migrationBuilder.CreateIndex(
                name: "IX_ProizvodiKategorija_KategorijaIdKategorije",
                table: "ProizvodiKategorija",
                column: "KategorijaIdKategorije");

            migrationBuilder.CreateIndex(
                name: "IX_ProizvodiKategorija_NarudzbenicaIdNarudzbenice",
                table: "ProizvodiKategorija",
                column: "NarudzbenicaIdNarudzbenice");

            migrationBuilder.CreateIndex(
                name: "IX_ProizvodiKategorija_ProizvodiIdProizvoda",
                table: "ProizvodiKategorija",
                column: "ProizvodiIdProizvoda");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdavnicaKategorija");

            migrationBuilder.DropTable(
                name: "ProizvodiKategorija");

            migrationBuilder.DropTable(
                name: "Prodavnica");

            migrationBuilder.DropTable(
                name: "Kategorije");

            migrationBuilder.DropTable(
                name: "Narudzbenica");

            migrationBuilder.DropTable(
                name: "Proizvodi");
        }
    }
}
