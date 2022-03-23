using Microsoft.EntityFrameworkCore.Migrations;

namespace Odnesi.Migrations
{
    public partial class V7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProdavnicaKategorija_Narudzbenica_NarudzbenicaIdNarudzbenice",
                table: "ProdavnicaKategorija");

            migrationBuilder.DropTable(
                name: "ProizvodiKategorija");

            migrationBuilder.DropTable(
                name: "Narudzbenica");

            migrationBuilder.RenameColumn(
                name: "NarudzbenicaIdNarudzbenice",
                table: "ProdavnicaKategorija",
                newName: "ProizvodIdProizvoda");

            migrationBuilder.RenameIndex(
                name: "IX_ProdavnicaKategorija_NarudzbenicaIdNarudzbenice",
                table: "ProdavnicaKategorija",
                newName: "IX_ProdavnicaKategorija_ProizvodIdProizvoda");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdavnicaKategorija_Proizvodi_ProizvodIdProizvoda",
                table: "ProdavnicaKategorija",
                column: "ProizvodIdProizvoda",
                principalTable: "Proizvodi",
                principalColumn: "IdProizvoda",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProdavnicaKategorija_Proizvodi_ProizvodIdProizvoda",
                table: "ProdavnicaKategorija");

            migrationBuilder.RenameColumn(
                name: "ProizvodIdProizvoda",
                table: "ProdavnicaKategorija",
                newName: "NarudzbenicaIdNarudzbenice");

            migrationBuilder.RenameIndex(
                name: "IX_ProdavnicaKategorija_ProizvodIdProizvoda",
                table: "ProdavnicaKategorija",
                newName: "IX_ProdavnicaKategorija_NarudzbenicaIdNarudzbenice");

            migrationBuilder.CreateTable(
                name: "Narudzbenica",
                columns: table => new
                {
                    IdNarudzbenice = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdresaKupca = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DatumNarudzbenice = table.Column<int>(type: "int", nullable: false),
                    ImeiPrezime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Racun = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Narudzbenica", x => x.IdNarudzbenice);
                });

            migrationBuilder.CreateTable(
                name: "ProizvodiKategorija",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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

            migrationBuilder.AddForeignKey(
                name: "FK_ProdavnicaKategorija_Narudzbenica_NarudzbenicaIdNarudzbenice",
                table: "ProdavnicaKategorija",
                column: "NarudzbenicaIdNarudzbenice",
                principalTable: "Narudzbenica",
                principalColumn: "IdNarudzbenice",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
