using Microsoft.EntityFrameworkCore.Migrations;

namespace Odnesi.Migrations
{
    public partial class v11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kategorije_Prodavnica_ProdavnicaIdProdavnice",
                table: "Kategorije");

            migrationBuilder.DropIndex(
                name: "IX_Kategorije_ProdavnicaIdProdavnice",
                table: "Kategorije");

            migrationBuilder.DropColumn(
                name: "ProdavnicaIdProdavnice",
                table: "Kategorije");

            migrationBuilder.CreateTable(
                name: "KategorijaProdavnica",
                columns: table => new
                {
                    KategorijeProdavniceIdKategorije = table.Column<int>(type: "int", nullable: false),
                    KategorijeProdavniceIdProdavnice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KategorijaProdavnica", x => new { x.KategorijeProdavniceIdKategorije, x.KategorijeProdavniceIdProdavnice });
                    table.ForeignKey(
                        name: "FK_KategorijaProdavnica_Kategorije_KategorijeProdavniceIdKategorije",
                        column: x => x.KategorijeProdavniceIdKategorije,
                        principalTable: "Kategorije",
                        principalColumn: "IdKategorije",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KategorijaProdavnica_Prodavnica_KategorijeProdavniceIdProdavnice",
                        column: x => x.KategorijeProdavniceIdProdavnice,
                        principalTable: "Prodavnica",
                        principalColumn: "IdProdavnice",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KategorijaProdavnica_KategorijeProdavniceIdProdavnice",
                table: "KategorijaProdavnica",
                column: "KategorijeProdavniceIdProdavnice");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KategorijaProdavnica");

            migrationBuilder.AddColumn<int>(
                name: "ProdavnicaIdProdavnice",
                table: "Kategorije",
                type: "int",
                nullable: true);

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
        }
    }
}
