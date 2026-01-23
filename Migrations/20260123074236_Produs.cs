using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ghita_Vlad_Proiect_Facturi.Migrations
{
    /// <inheritdoc />
    public partial class Produs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cantitate",
                table: "Facturi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProdusID",
                table: "Facturi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Facturi_ProdusID",
                table: "Facturi",
                column: "ProdusID");

            migrationBuilder.AddForeignKey(
                name: "FK_Facturi_Produse_ProdusID",
                table: "Facturi",
                column: "ProdusID",
                principalTable: "Produse",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facturi_Produse_ProdusID",
                table: "Facturi");

            migrationBuilder.DropIndex(
                name: "IX_Facturi_ProdusID",
                table: "Facturi");

            migrationBuilder.DropColumn(
                name: "Cantitate",
                table: "Facturi");

            migrationBuilder.DropColumn(
                name: "ProdusID",
                table: "Facturi");
        }
    }
}
