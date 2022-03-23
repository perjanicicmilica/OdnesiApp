using Microsoft.EntityFrameworkCore.Migrations;

namespace Odnesi.Migrations
{
    public partial class v9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KategorijaIdKategorije",
                table: "Proizvodi",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProdavnicaIdProdavnice",
                table: "Kategorije",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Proizvodi_KategorijaIdKategorije",
                table: "Proizvodi",
                column: "KategorijaIdKategorije");

            migrationBuilder.CreateIndex(
                name: "IX_Kategorije_ProdavnicaIdProdavnice",
                table: "Kategorije",
                column: "ProdavnicaIdProdavnice");

            migrationBuilder.AddForeignKey(
                name: "FK_Kategorije_Prodavnica_ProdavnicaIdProdavnice",
                table: "Kategorije",
                column: "ProdavnicaIdProdavnice",
                principalTable: "Prodavnica",
                principalColumn: "IdProdavnice",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Proizvodi_Kategorije_KategorijaIdKategorije",
                table: "Proizvodi",
                column: "KategorijaIdKategorije",
                principalTable: "Kategorije",
                principalColumn: "IdKategorije",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kategorije_Prodavnica_ProdavnicaIdProdavnice",
                table: "Kategorije");

            migrationBuilder.DropForeignKey(
                name: "FK_Proizvodi_Kategorije_KategorijaIdKategorije",
                table: "Proizvodi");

            migrationBuilder.DropIndex(
                name: "IX_Proizvodi_KategorijaIdKategorije",
                table: "Proizvodi");

            migrationBuilder.DropIndex(
                name: "IX_Kategorije_ProdavnicaIdProdavnice",
                table: "Kategorije");

            migrationBuilder.DropColumn(
                name: "KategorijaIdKategorije",
                table: "Proizvodi");

            migrationBuilder.DropColumn(
                name: "ProdavnicaIdProdavnice",
                table: "Kategorije");
        }
    }
}
