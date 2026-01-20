using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ghita_Vlad_Proiect_Facturi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parteneri",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CUI = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Adresa = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tip = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parteneri", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Facturi",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Serie = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Numar = table.Column<int>(type: "int", nullable: false),
                    DataEmiterii = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataScadentei = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipFactura = table.Column<int>(type: "int", nullable: false),
                    PartenerID = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stare = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturi", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Facturi_Parteneri_PartenerID",
                        column: x => x.PartenerID,
                        principalTable: "Parteneri",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Facturi_PartenerID",
                table: "Facturi",
                column: "PartenerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Facturi");

            migrationBuilder.DropTable(
                name: "Parteneri");
        }
    }
}
