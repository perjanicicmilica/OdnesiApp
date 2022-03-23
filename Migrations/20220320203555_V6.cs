using Microsoft.EntityFrameworkCore.Migrations;

namespace Odnesi.Migrations
{
    public partial class V6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ocena",
                table: "ProizvodiKategorija");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Ocena",
                table: "ProizvodiKategorija",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
